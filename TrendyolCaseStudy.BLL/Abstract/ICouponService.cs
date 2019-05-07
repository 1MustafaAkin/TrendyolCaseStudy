using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.BLL.Abstract
{
    public interface ICouponService
    {
        IEnumerable<Coupon> GetAll();
        Coupon GetCouponById(int? id);
        void Add(Coupon coupon);
        void Update(Coupon coupon);
        void Delete(Coupon coupon);
    }
}
