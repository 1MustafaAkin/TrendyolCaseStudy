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
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void Add(Customer customer)
        {
            _customerDal.Add(customer);
        }

        public void Delete(Customer customer)
        {
            try
            {
                _customerDal.Delete(customer);
            }
            catch
            {
                throw new Exception("Silme Gerçekleşemedi");
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerDal.GetAll();
        }

        public Customer GetCustomerById(int? id)
        {
            return _customerDal.Get(x=>x.CustomerID==id);
        }

        public Customer GetCustomerByUserName(string userName)
        {
            return _customerDal.Get(x => x.UserName == userName);
        }

        public Customer GetLoginCustomer(string userName, string password)
        {
            return _customerDal.Get(x => x.UserName == userName && x.Password == password);
        }

        public void Update(Customer customer)
        {
            _customerDal.Update(customer);
        }
    }
}
