using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.BLL.Abstract;
using TrendyolCaseStudy.Dal.Abstract;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.BLL.Concrete
{
    public class OrderDetailManager : IOrderDetailsService
    {
        private IOrderDetailsDal _orderDetailsDal;

        public OrderDetailManager(IOrderDetailsDal orderDetailsDal)
        {
            _orderDetailsDal = orderDetailsDal;
        }

        public void Add(OrderDetails orderDetails)
        {
            _orderDetailsDal.Add(orderDetails);
        }

        public void Delete(OrderDetails orderDetails)
        {
            try
            {
                _orderDetailsDal.Delete(orderDetails);
            }
            catch
            {
                throw new Exception("Silme gerçekleşemedi");
            }
        }

        public IEnumerable<OrderDetails> GetAll()
        {
            return _orderDetailsDal.GetAll();
        }

        public IEnumerable<OrderDetails> GetAllWithIncludeByCurrentUserId(int id,bool isCompleted,params string[] include)
        {
            return _orderDetailsDal.GetAllWithInclude(x => x.CustomerID == id && x.IsCompleted == isCompleted,include);
        }

        public OrderDetails GetOrderDetailsByCurrentUserIdAndProductId(int productId, int userId , bool isCompleted)
        {
            return _orderDetailsDal.Get(x => x.ProductID == productId && x.CustomerID == userId && x.IsCompleted==isCompleted);
        }

        public OrderDetails GetOrderDetailsById(int? id)
        {
            return _orderDetailsDal.Get(x => x.OrderDetailID == id);
        }

        public int GetNumberOfProduct(int id , bool isCompleted)
        {
            return _orderDetailsDal.GetAll(x => x.CustomerID == id && x.IsCompleted == isCompleted).Count();
        }

        public int GetNumberOfDelivery(int id, bool isCompleted)
        {
            return _orderDetailsDal.GetAllWithInclude(x => x.CustomerID == id && x.IsCompleted == isCompleted,"Product").GroupBy(x=>x.Product.SubCategoryID).Distinct().Count();
        }

        public void Update(OrderDetails orderDetails)
        {
            _orderDetailsDal.Update(orderDetails);
        }

        public OrderDetails GetOrderDetailsByCustomerAndProductWithInclude(int productId, int userId, bool isCompleted)
        {
            return _orderDetailsDal.GetAllWithInclude(x => x.ProductID == productId && x.CustomerID == userId && x.IsCompleted == isCompleted,"Product").FirstOrDefault();
        }

        public OrderDetails GetOrderDetailsByCustomerId(int? id)
        {
            return _orderDetailsDal.Get(x => x.CustomerID == id);
        }

    }
}
