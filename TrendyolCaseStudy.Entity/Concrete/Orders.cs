using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Entity.Abstract;

namespace TrendyolCaseStudy.Entity.Concrete
{
    public class Orders : IEntity
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsCompleted { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }


        public int OrderDetailID { get; set; }
        public int ShippingDetailID { get; set; }

        public virtual OrderDetails OrderDetail { get; set; }
        public virtual ShippingDetail ShippingDetail { get; set; }

    }
}
