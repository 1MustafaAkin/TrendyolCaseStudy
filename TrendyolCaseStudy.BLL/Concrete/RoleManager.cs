using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.BLL.Abstract;
using TrendyolCaseStudy.Dal.Abstract;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.BLL.Concrete
{
    public class RoleManager : IRoleService
    {
        private IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public void Add(Role role)
        {
            _roleDal.Add(role);
        }

        public void Delete(Role role)
        {
            try
            {
                _roleDal.Delete(role);
            }
            catch
            {
                throw new Exception("Silme gerçekleşemedi");
            }
        }

        public IEnumerable<Role> GetAll()
        {
            return _roleDal.GetAll();
        }

        public Role GetRoleById(int? id)
        {
            return _roleDal.Get(x => x.RoleID == id);
        }

        public void Update(Role role)
        {
            _roleDal.Update(role);
        }
    }
}
