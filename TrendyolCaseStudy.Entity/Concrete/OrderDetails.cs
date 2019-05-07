using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Entity.Abstract;

namespace TrendyolCaseStudy.Entity.Concrete
{ 
    public class OrderDetails : IEntity
    {
        public int OrderDetailID { get; set; }
       
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalAmountBeforeDiscount { get; set; }
        public bool IsCompleted { get; set; }
        public decimal DeliveryCost { get; set; }


        public int? CouponID { get; set; }
        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public virtual Product Product { get; set; }
        public virtual Coupon Coupon { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
