using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Dal.Abstract;
using TrendyolCaseStudy.Dal.Mapping;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.Dal.Concrete
{
    public class EfProductDal : EfRepository<Product, Context>, IProductDal
    {
    }
}
