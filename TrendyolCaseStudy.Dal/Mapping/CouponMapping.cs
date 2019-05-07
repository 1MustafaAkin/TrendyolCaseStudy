using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.Dal.Mapping
{
    public class CouponMapping : EntityTypeConfiguration<Coupon>
    {
        public CouponMapping()
        {
            HasKey(x => x.CouponID);
            Property(x => x.CouponName).HasMaxLength(20);
            Property(x => x.CouponDisocunt).HasColumnType("money");
        }
    }
}
