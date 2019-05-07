using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.Dal.Mapping
{
    public class OrderDetailsMapping : EntityTypeConfiguration<OrderDetails>
    {
        public OrderDetailsMapping()
        {
            HasKey(x => x.OrderDetailID);

            Property(x => x.UnitPrice).HasColumnType("money");
            Property(x => x.Discount).HasColumnType("money").IsOptional();
            Property(x => x.TotalAmount).HasColumnType("money");
            Property(x => x.TotalAmountBeforeDiscount).HasColumnType("money");
            Property(x => x.DeliveryCost).HasColumnType("money");

            HasRequired(x => x.Customer).WithMany(x => x.OrderDetails).HasForeignKey(x => x.CustomerID);
            HasRequired(x => x.Product).WithMany(x => x.OrderDetails).HasForeignKey(x => x.ProductID);
        }
    }
}
