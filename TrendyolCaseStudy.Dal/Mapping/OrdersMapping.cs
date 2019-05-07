using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.Dal.Mapping
{
    public class OrdersMapping : EntityTypeConfiguration<Orders>
    {
        public OrdersMapping()
        {
            HasKey(x => x.OrderID);

            Property(x => x.OrderDate).HasColumnType("datetime");
            Property(x => x.ShippedDate).HasColumnType("datetime");
            Property(x => x.Freight).HasColumnType("money");
            Property(x => x.TotalAmount).HasColumnType("money");
            Property(x => x.ShipAddress).HasMaxLength(50);
            Property(x => x.ShipCity).HasMaxLength(20);
            Property(x => x.ShipCountry).HasMaxLength(20);

            HasRequired(x => x.ShippingDetail).WithMany(x => x.Orders).HasForeignKey(x => x.ShippingDetailID);

        }
    }
}
