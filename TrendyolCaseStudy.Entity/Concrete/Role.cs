using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Entity.Abstract;

namespace TrendyolCaseStudy.Entity.Concrete
{
    public class Role : IEntity
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
