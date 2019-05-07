using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.BLL.Abstract
{
    public interface IOrderDetailsService 
    {
        IEnumerable<OrderDetails> GetAll();
        OrderDetails GetOrderDetailsById(int? id);
        OrderDetails GetOrderDetailsByCustomerId(int? id);
        OrderDetails GetOrderDetailsByCurrentUserIdAndProductId(int productId , int userId , bool isCompleted);
        OrderDetails GetOrderDetailsByCustomerAndProductWithInclude(int productId , int userId , bool isCompleted);
        IEnumerable<OrderDetails> GetAllWithIncludeByCurrentUserId(int id,bool isCompleted ,params string[] include);
        int GetNumberOfProduct(int id, bool isCompleted);
        int GetNumberOfDelivery(int id, bool isCompleted);
        void Add(OrderDetails orderDetails);
        void Update(OrderDetails orderDetails);
        void Delete(OrderDetails orderDetails);
    }
}
