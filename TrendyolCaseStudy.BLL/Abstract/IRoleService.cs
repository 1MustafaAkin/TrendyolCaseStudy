using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.BLL.Abstract
{
    public interface IRoleService
    {
        IEnumerable<Role> GetAll();
        Role GetRoleById(int? id);
        void Add(Role role);
        void Update(Role role);
        void Delete(Role role);
    }
}
