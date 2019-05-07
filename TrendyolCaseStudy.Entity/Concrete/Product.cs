using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Entity.Abstract;

namespace TrendyolCaseStudy.Entity.Concrete
{
    public class Product : IEntity
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public decimal Discount { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        public int SubCategoryID { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
