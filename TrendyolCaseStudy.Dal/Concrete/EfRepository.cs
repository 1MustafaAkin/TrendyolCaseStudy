using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrendyolCaseStudy.Dal.Abstract;
using TrendyolCaseStudy.Entity.Abstract;

namespace TrendyolCaseStudy.Dal.Concrete
{
    public class EfRepository<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : class , IEntity,new ()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext db = new TContext())
            {
                var addedEntity = db.Entry(entity);
                addedEntity.State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext db = new TContext())
            {
                var deletedEntity = db.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext db = new TContext())
            {
                var updatedEntity = db.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext db = new TContext())
            {
                return db.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext db = new TContext())
            {
                return filter == null ? db.Set<TEntity>().ToList() : db.Set<TEntity>().Where(filter).ToList();
            }
        }

        public IEnumerable<TEntity> GetAllWithInclude(Expression<Func<TEntity, bool>> filter, params string[] include)
        {
            using (TContext db = new TContext())
            {
                IQueryable<TEntity> query = db.Set<TEntity>();
                foreach (string inc in include)
                {
                    query = query.Include(inc);
                }

                return filter == null ? query.ToList() : query.Where(filter).ToList();
            }
        }
    }
}
