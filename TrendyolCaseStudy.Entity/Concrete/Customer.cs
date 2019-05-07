using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Entity.Abstract;

namespace TrendyolCaseStudy.Entity.Concrete
{
    public class Customer : IEntity
    {   
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        //[Range(6, 15, ErrorMessage = ("Şifre 6 karakterden fazla 15 karakterden az olmalı"))]
        public string Password { get; set; }
        //[Compare("Password", ErrorMessage = "Şifreler eşleşmiyor lütfen kontrol ediniz")]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        //[Phone]
        public string Phone { get; set; }
        ////[EmailAddress]
        public string Email { get; set; }

        public int RoleID { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
