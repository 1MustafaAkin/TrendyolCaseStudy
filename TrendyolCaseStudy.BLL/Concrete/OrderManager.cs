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
    public class OrderManager : IOrdersService
    {
        private IOrdersDal _ordersDal;

        public OrderManager(IOrdersDal ordersDal)
        {
            _ordersDal = ordersDal;
        }

        public void Add(Orders orders)
        {
            _ordersDal.Add(orders);
        }

        public void Delete(Orders orders)
        {
            try
            {
                _ordersDal.Delete(orders);
            }
            catch
            {
                throw new Exception("Silme Gerçekleşemedi");
            }
        }

        public IEnumerable<Orders> GetAll()
        {
            return _ordersDal.GetAll();
        }

        public Orders GetOrdersById(int? id)
        {
            return _ordersDal.Get(x => x.OrderID == id);
        }

        public void Update(Orders orders)
        {
            _ordersDal.Update(orders);
        }
    }
}
