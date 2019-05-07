using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.BLL.Abstract;
using TrendyolCaseStudy.BLL.Concrete;
using TrendyolCaseStudy.Dal.Abstract;
using TrendyolCaseStudy.Dal.Concrete;

namespace TrendyolCaseStudy.BLL.Dependency_Resolver.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();

            Bind<ICouponService>().To<CouponManager>().InSingletonScope();
            Bind<ICouponDal>().To<EfCouponDal>().InSingletonScope();

            Bind<ICustomerService>().To<CustomerManager>().InSingletonScope();
            Bind<ICustomerDal>().To<EfCustomerDal>().InSingletonScope();

            Bind<IOrderDetailsService>().To<OrderDetailManager>().InSingletonScope();
            Bind<IOrderDetailsDal>().To<EfOrderDetailsDal>().InSingletonScope();

            Bind<IOrdersService>().To<OrderManager>().InSingletonScope();
            Bind<IOrdersDal>().To<EfOrdersDal>().InSingletonScope();

            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind<IRoleService>().To<RoleManager>().InSingletonScope();
            Bind<IRoleDal>().To<EfRoleDal>().InSingletonScope();

            Bind<IShippingDetailService>().To<ShippingDetailManager>().InSingletonScope();
            Bind<IShippingDetailDal>().To<EfShippingDetailDal>().InSingletonScope();

            Bind<ISubCategoryService>().To<SubCategoryManager>().InSingletonScope();
            Bind<ISubCategoryDal>().To<EfSubCategoryDal>().InSingletonScope();
        }
    }
}
