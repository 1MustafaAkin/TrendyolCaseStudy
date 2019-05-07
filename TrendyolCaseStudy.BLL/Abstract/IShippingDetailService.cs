using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.BLL.Abstract
{
    public interface IShippingDetailService
    {
        IEnumerable<ShippingDetail> GetAll();
        ShippingDetail GetShippingDetailById(int? id);
        void Add(ShippingDetail shippingDetail);
        void Update(ShippingDetail shippingDetail);
        void Delete(ShippingDetail shippingDetail);
    }
}
