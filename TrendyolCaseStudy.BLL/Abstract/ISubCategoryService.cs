using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.BLL.Abstract
{
    public interface ISubCategoryService
    {
        IEnumerable<SubCategory> GetAll();
        SubCategory GetSubCategoryById(int? id);
        void Add(SubCategory subCategory);
        void Update(SubCategory subCategory);
        void Delete(SubCategory subCategory);
    }
}
