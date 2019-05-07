using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrendyolCaseStudy.App.Models;
using TrendyolCaseStudy.BLL.Abstract;
using TrendyolCaseStudy.BLL.Dependency_Resolver.Ninject;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.App.Controllers
{
    public class LoginController : Controller
    {
        private ICustomerService _customerService;

        public LoginController()
        {
            _customerService = InstanceFactory.GetInstance<ICustomerService>();
        }

        public ActionResult Register()
        {
            string urlName = Request.UrlReferrer.ToString();
            TemporaryUserData.LastUrl = urlName;
            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection frm)
        {
            string kullaniciAdi = frm["username"];
            Customer customer = _customerService.GetCustomerByUserName(kullaniciAdi);

            if (customer != null)
                return View();
            else
            {
                customer = new Customer();
                customer.FirstName = frm["name"].ToString();
                customer.LastName = frm["surname"].ToString();
                customer.UserName = frm["username"].ToString();
                customer.Password = frm["password"].ToString();
                customer.ConfirmPassword = frm["confirmpassword"].ToString();
                customer.Address = frm["address"].ToString();
                customer.City = frm["city"].ToString();
                customer.Country = frm["country"].ToString();
                customer.Phone = frm["phone"].ToString();
                customer.Email = frm["email"].ToString();
                customer.RoleID = 2;

                _customerService.Add(customer);

                Session["OnlineKullanici"] = customer.UserName;
                TemporaryUserData.UserID = customer.CustomerID;
                return Redirect(TemporaryUserData.LastUrl);
            }

        }

        public ActionResult Login()
        {
            string urlName = Request.UrlReferrer.ToString();
            TemporaryUserData.LastUrl = urlName;
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {
            string kullaniciAdi = frm["username"];
            string sifre = frm["password"];

            Customer customer = _customerService.GetLoginCustomer(kullaniciAdi,sifre);
            if (customer != null)
            {
                Session["OnlineKullanici"] = customer.UserName;
                TemporaryUserData.UserID = customer.CustomerID;

                return Redirect(TemporaryUserData.LastUrl);
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["OnlineKullanici"] = null;
            TemporaryUserData.UserID = 0;
            return RedirectToAction("Index", "Home");
        }
    }
}