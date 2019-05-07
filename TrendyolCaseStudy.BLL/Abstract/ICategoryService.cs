using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Entity.Concrete;

namespace TrendyolCaseStudy.BLL.Abstract
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        Category GetCategoryById(int? id);
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
