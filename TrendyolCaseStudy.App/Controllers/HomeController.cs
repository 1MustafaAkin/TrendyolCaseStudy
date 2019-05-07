using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrendyolCaseStudy.BLL.Abstract;
using TrendyolCaseStudy.BLL.Dependency_Resolver.Ninject;

namespace TrendyolCaseStudy.App.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;

        public HomeController()
        {
            _productService = InstanceFactory.GetInstance<IProductService>();
        }

        public ActionResult Index()
        {
            return View(_productService.GetAll());
        }
    }
}