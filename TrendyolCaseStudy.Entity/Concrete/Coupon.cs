using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Entity.Abstract;

namespace TrendyolCaseStudy.Entity.Concrete
{
    public class Coupon : IEntity
    {
        public int CouponID { get; set; }
        public string CouponName { get; set; }
        public decimal CouponDisocunt { get; set; }
        public int CartMinValue { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
