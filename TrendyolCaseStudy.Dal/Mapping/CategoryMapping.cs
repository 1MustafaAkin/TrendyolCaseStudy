using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.Dal.Mapping
{
    public class CategoryMapping: EntityTypeConfiguration<Category>
    {

        public CategoryMapping()
        {
            HasKey(x => x.CategoryID);

            Property(x => x.CategoryName).HasMaxLength(20);
            Property(x => x.Description).HasMaxLength(40).IsOptional();
        }
    }
}
