using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.Dal.Mapping
{
    public class CustomerMapping : EntityTypeConfiguration<Customer>
    {
        public CustomerMapping()
        {
            HasKey(x => x.CustomerID);

            Property(x => x.FirstName).HasMaxLength(20);
            Property(x => x.LastName).HasMaxLength(20);
            Property(x => x.UserName).HasMaxLength(15);
            Property(x => x.Address).HasMaxLength(50).IsOptional();
            Property(x => x.City).HasMaxLength(20);
            Property(x => x.Country).HasMaxLength(20);
            Property(x => x.Phone).HasMaxLength(15);
            Property(x => x.Email).HasMaxLength(20);
        }
    }
}
