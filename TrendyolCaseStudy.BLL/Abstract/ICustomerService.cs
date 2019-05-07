using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.BLL.Abstract
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer GetCustomerById(int? id);
        Customer GetCustomerByUserName(string userName);
        Customer GetLoginCustomer(string userName,string password);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}
