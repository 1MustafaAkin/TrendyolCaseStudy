using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.Dal.Mapping
{
    public class SubCategoryMapping : EntityTypeConfiguration<SubCategory>
    {
        public SubCategoryMapping()
        {
            HasKey(x => x.SubCategoryID);

            Property(x => x.Name).HasMaxLength(20);
            Property(x => x.Description).HasMaxLength(50).IsOptional();
        }
    }
}
