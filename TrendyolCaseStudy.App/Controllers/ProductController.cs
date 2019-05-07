using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrendyolCaseStudy.BLL.Abstract;
using TrendyolCaseStudy.BLL.Dependency_Resolver.Ninject;

namespace TrendyolCaseStudy.App.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController()
        {
            _productService = InstanceFactory.GetInstance<IProductService>();
        }

        public ActionResult ProductDetail(int id)
        {
            return View(_productService.GetProductById(id));
        }
    }
}