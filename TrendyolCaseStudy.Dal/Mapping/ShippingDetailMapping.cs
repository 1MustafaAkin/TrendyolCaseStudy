using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.Dal.Mapping
{
    public class ShippingDetailMapping : EntityTypeConfiguration<ShippingDetail>
    {
        public ShippingDetailMapping()
        {
            HasKey(x => x.ShippingDetailID);

            Property(x => x.FirstName).HasMaxLength(20);
            Property(x => x.LastName).HasMaxLength(20);
            Property(x => x.Phone).HasMaxLength(20);
            Property(x => x.Address).HasMaxLength(20);
            Property(x => x.City).HasMaxLength(20);
            Property(x => x.Email).HasMaxLength(20).IsOptional();
        }
    }
}
