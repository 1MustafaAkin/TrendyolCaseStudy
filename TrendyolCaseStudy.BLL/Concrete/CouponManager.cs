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
    public class CouponManager : ICouponService
    {
        private ICouponDal _couponDal;

        public CouponManager(ICouponDal couponDal)
        {
            _couponDal = couponDal;
        }

        public void Add(Coupon coupon)
        {
            _couponDal.Add(coupon);
        }

        public void Delete(Coupon coupon)
        {
            try
            {
                _couponDal.Delete(coupon);
            }
            catch
            {
                throw new Exception("Silme gerçekleşemedi");
            }
        }

        public IEnumerable<Coupon> GetAll()
        {
            return _couponDal.GetAll();
        }

        public Coupon GetCouponById(int? id)
        {
            return _couponDal.Get(x => x.CouponID == id);
        }

        public void Update(Coupon coupon)
        {
            _couponDal.Update(coupon);
        }
    }
}
