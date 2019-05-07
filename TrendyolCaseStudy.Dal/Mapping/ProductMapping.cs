using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.Dal.Mapping
{
    public class ProductMapping : EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            HasKey(x => x.ProductID);

            Property(x => x.ProductName).HasMaxLength(20);
            Property(x => x.UnitPrice).HasColumnType("money");
            Property(x => x.Discount).HasColumnType("money").IsOptional();
            Property(x => x.ImageUrl).HasMaxLength(100);
            Property(x => x.Description).HasMaxLength(50).IsOptional();
            Property(x => x.Picture).HasMaxLength(100).IsOptional();
        }
    }
}
