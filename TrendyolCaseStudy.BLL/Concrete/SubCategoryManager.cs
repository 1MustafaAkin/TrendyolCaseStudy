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
    public class SubCategoryManager : ISubCategoryService
    {
        private ISubCategoryDal _subCategoryDal;

        public SubCategoryManager(ISubCategoryDal subCategoryDal)
        {
            _subCategoryDal = subCategoryDal;
        }

        public void Add(SubCategory subCategory)
        {
            _subCategoryDal.Add(subCategory);
        }

        public void Delete(SubCategory subCategory)
        {
            try
            {
                _subCategoryDal.Delete(subCategory);
            }
            catch
            {
                throw new Exception("Silme Gerçekleşemedi");
            }
        }

        public IEnumerable<SubCategory> GetAll()
        {
            return _subCategoryDal.GetAll();
        }

        public SubCategory GetSubCategoryById(int? id)
        {
            return _subCategoryDal.Get(x => x.SubCategoryID == id);
        }

        public void Update(SubCategory subCategory)
        {
            _subCategoryDal.Update(subCategory);
        }
    }
}
