using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrendyolCaseStudy.App.Interfaces;
using TrendyolCaseStudy.BLL.Abstract;
using TrendyolCaseStudy.BLL.Dependency_Resolver.Ninject;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.App.Models
{
    public class Cart : ICart
    {
        private IProductService _productService;
        private IOrderDetailsService _orderDetailsService;
        OrderDetails od;
        public static decimal totalDiscount = 0;

        public Cart()
        {
            _productService = InstanceFactory.GetInstance<IProductService>();
            _orderDetailsService = InstanceFactory.GetInstance<IOrderDetailsService>();
        }

        public void ApplyDiscount(Campaign discount)
        {
            IEnumerable<Product> products = _productService.GetAllByCategoryId(discount._categoryId);
            
            foreach (var item in products)
            {
                od = _orderDetailsService.GetOrderDetailsByCustomerAndProductWithInclude(item.ProductID, TemporaryUserData.UserID, false);
                if (od != null)
                {
                    if (discount._discount == discount._quantity)
                    { 
                        od.TotalAmount = od.Quantity * od.UnitPrice - discount._discount;
                    }
                    else
                    {
                        od.Discount = discount._discount;
                        totalDiscount = od.Discount;
                        od.TotalAmount = od.Quantity * od.UnitPrice * (1 - od.Discount);
                    }
                    _orderDetailsService.Update(od);
                }
            }
        }
    }
}