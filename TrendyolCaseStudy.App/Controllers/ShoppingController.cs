using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrendyolCaseStudy.App.Interfaces;
using TrendyolCaseStudy.App.Models;
using TrendyolCaseStudy.BLL.Abstract;
using TrendyolCaseStudy.BLL.Dependency_Resolver.Ninject;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.App.Controllers
{
    public class ShoppingController : Controller
    {
        private IOrderDetailsService _orderDetailsService;
        private IProductService _productService;
        private ICustomerService _customerService;
        private IShippingDetailService _shippingDetailService;
        private IOrdersService _ordersService;
        private ICouponService _couponService;
        private ICart _cart;

        const int costPerDelivery = 10;
        const int costPerProduct = 5;
        int numberOfProduct;
        int numberOfDelivery;
        int toplmaMiktar = 0;

        public ShoppingController()
        {
            _orderDetailsService = InstanceFactory.GetInstance<IOrderDetailsService>();
            _productService = InstanceFactory.GetInstance<IProductService>();
            _customerService = InstanceFactory.GetInstance<ICustomerService>();
            _shippingDetailService = InstanceFactory.GetInstance<IShippingDetailService>();
            _ordersService = InstanceFactory.GetInstance<IOrdersService>();
            _couponService = InstanceFactory.GetInstance<ICouponService>();
        }

        [HttpPost]
        public ActionResult AddToCart(int id, FormCollection frm)
        {
            if (Session["OnlineKullanici"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            int miktar = 1;
            if (frm["miktar"] != null)
                miktar = short.Parse(frm["miktar"]);
            ControlCart(id, miktar);

            return RedirectToAction("ProductDetail", "Product", new { id = id });
        }

        public void ControlCart(int id, int miktar = 1)
        {
            OrderDetails od = _orderDetailsService.GetOrderDetailsByCurrentUserIdAndProductId(id, TemporaryUserData.UserID, false);
            IEnumerable<Coupon> coupons = _couponService.GetAll();

            toplmaMiktar += miktar;
            int categoryId = _productService.GetProductById(id).SubCategoryID;
            DeliveryCostCalculator deliveryCostCalculator;


            if (od == null)
            {
                od = new OrderDetails();
                od.ProductID = id;
                od.CustomerID = TemporaryUserData.UserID;
                od.IsCompleted = false;
                od.UnitPrice = _productService.GetProductById(id).UnitPrice;

                if (_productService.GetProductById(id).UnitsInStock >= miktar)
                {
                    od.Quantity = miktar;
                }
                else
                {
                    od.Quantity = _productService.GetProductById(id).UnitsInStock;
                }
                
                od.TotalAmount = od.Quantity * od.UnitPrice * (1 - od.Discount);
                od.TotalAmountBeforeDiscount = od.Quantity * od.UnitPrice;

                _orderDetailsService.Add(od);

                numberOfProduct = _orderDetailsService.GetNumberOfProduct(TemporaryUserData.UserID, false);
                numberOfDelivery = _orderDetailsService.GetNumberOfDelivery(TemporaryUserData.UserID, false);

                deliveryCostCalculator = new DeliveryCostCalculator(costPerDelivery, costPerProduct, numberOfDelivery, numberOfProduct);
                od.DeliveryCost = deliveryCostCalculator.calculateFor(od);
                _orderDetailsService.Update(od);

                if (toplmaMiktar > 5)
                    ApplyDiscount(categoryId, 0.50m, toplmaMiktar);
                else if (toplmaMiktar > 3)
                    ApplyDiscount(categoryId, 0.20m, toplmaMiktar);
                else
                    ApplyDiscount(categoryId, toplmaMiktar, toplmaMiktar);
            }
            else
            {
                if (_productService.GetProductById(id).UnitsInStock > od.Quantity + miktar)
                {
                    numberOfProduct = _orderDetailsService.GetNumberOfProduct(TemporaryUserData.UserID, false);
                    numberOfDelivery = _orderDetailsService.GetNumberOfDelivery(TemporaryUserData.UserID, false);
                    deliveryCostCalculator = new DeliveryCostCalculator(costPerDelivery, costPerProduct, numberOfDelivery, numberOfProduct);
                    od.Quantity += miktar;
                    od.TotalAmount = od.UnitPrice * od.Quantity * (1 - od.Discount);
                    od.DeliveryCost = deliveryCostCalculator.calculateFor(od);
                    _orderDetailsService.Update(od);
                }
            }

        }

        private void ApplyDiscount(int categoryId, decimal rate, int toplamMiktar)
        {
            Campaign campaign = new Campaign(categoryId, rate, toplamMiktar);
            _cart = new Cart();
            _cart.ApplyDiscount(campaign);
        }

        public ActionResult Cart()
        {
            return View(_orderDetailsService.GetAllWithIncludeByCurrentUserId(TemporaryUserData.UserID, false, "Product", "Customer"));
        }

        public ActionResult RemoveFromCart(int id)
        {
            OrderDetails od = _orderDetailsService.GetOrderDetailsById(id);
            _orderDetailsService.Delete(od);
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult GoToPayment()
        {
            IEnumerable<OrderDetails> cart = _orderDetailsService.GetAllWithIncludeByCurrentUserId(TemporaryUserData.UserID, false, "Product", "Customer");

            foreach (var item in cart)
            {
                if (item.Product.UnitsInStock < item.Quantity)
                {
                    return RedirectToAction("UpdateCart", "Shopping");
                }
            }

            ViewBag.OrderDetails = cart;
            return View(_customerService.GetCustomerById(TemporaryUserData.UserID));
        }

        public ActionResult UpdateCart()
        {
            return View(_orderDetailsService.GetAllWithIncludeByCurrentUserId(TemporaryUserData.UserID, false, "Product", "Customer"));
        }

        [HttpPost]
        public ActionResult CompleteShopping(FormCollection frm)
        {
            if (frm["update"] == "on")
            {
                Customer customer = _customerService.GetCustomerById(TemporaryUserData.UserID);
                customer.FirstName = frm["FirstName"];
                customer.LastName = frm["LastName"];
                customer.Address = frm["Address"];
                customer.City = frm["City"];
                _customerService.Update(customer);
            }

            ShippingDetail sp = new ShippingDetail();
            sp.FirstName = frm["FirstName"];
            sp.LastName = frm["LastName"];
            sp.Address = frm["Address"];
            sp.City = frm["City"];

            _shippingDetailService.Add(sp);


            IEnumerable<OrderDetails> cart = _orderDetailsService.GetAllWithIncludeByCurrentUserId(TemporaryUserData.UserID, false, "Product", "Customer");

            foreach (var item in cart)
            {
                item.IsCompleted = true;
                item.Product.UnitsInStock -= item.Quantity;
                _orderDetailsService.Update(item);
                _productService.Update(item.Product);
                Orders order = new Orders()
                {
                    ShippingDetailID = sp.ShippingDetailID,
                    OrderDetailID = item.OrderDetailID,
                    TotalAmount = item.TotalAmount,
                    IsCompleted = true,
                    OrderDate = DateTime.Now,
                    ShippedDate = DateTime.Now.AddDays(3),
                };
                _ordersService.Add(order);
            }
            return RedirectToAction("FinishShopping", "Shopping");
        }

        public ActionResult FinishShopping()
        {
            return View();
        }
    }
}