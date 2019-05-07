using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Entity.Abstract;

namespace TrendyolCaseStudy.Dal.Abstract
{
    public interface IRepositoryBase<T> where T : class, IEntity, new()
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAllWithInclude(Expression<Func<T, bool>> filter, params string[] include);
    }
}
