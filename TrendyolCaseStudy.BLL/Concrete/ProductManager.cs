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
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            try
            {
                _productDal.Delete(product);
            }
            catch
            {
                throw new Exception("Silme gerçekleşemedi");
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public IEnumerable<Product> GetAllByCategoryId(int? id)
        {
            return _productDal.GetAll(x => x.SubCategoryID == id);
        }

        public Product GetProductById(int? id)
        {
            return _productDal.Get(x => x.ProductID == id);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
