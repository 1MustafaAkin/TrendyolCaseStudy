using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.BLL.Abstract
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetProductById(int? id);
        IEnumerable<Product> GetAllByCategoryId(int? id);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
