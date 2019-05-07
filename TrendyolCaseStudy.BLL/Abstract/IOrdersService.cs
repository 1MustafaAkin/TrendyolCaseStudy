using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.BLL.Abstract
{
    public interface IOrdersService
    {
        IEnumerable<Orders> GetAll();
        Orders GetOrdersById(int? id);
        void Add(Orders orders);
        void Update(Orders orders);
        void Delete(Orders orders);
    }
}
