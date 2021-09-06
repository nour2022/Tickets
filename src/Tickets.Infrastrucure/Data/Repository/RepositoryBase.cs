using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Tickets.Infrastrucure.Data.Repository
{
    public class RepositoryBase<TContext, TEntity> : IRepositoryBase<TContext, TEntity>
    where TContext : TicketsDbContext
    where TEntity : class
    {
        protected TContext DbContext { get; }

        protected DbSet<TEntity> DbSet { get; }


        public RepositoryBase(TContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }


        public virtual IQueryable<TEntity> Table => DbSet;

        public virtual IQueryable<TEntity> TableNoTracking => DbSet.AsNoTracking();

        public TEntity Insert(TEntity entity, bool autoSave = false)
        {
            var savedEntity = DbSet.Add(entity).Entity;

            if (autoSave)
            {
                DbContext.SaveChanges();
            }

            return savedEntity;
        }

        public void Insert(IEnumerable<TEntity> entities, bool autoSave = false)
        {
            DbSet.AddRange(entities);

            if (autoSave)
            {
                DbContext.SaveChanges();
            }
        }

        public async Task InsertAsync(IEnumerable<TEntity> entities, bool autoSave = false)
        {
            DbSet.AddRange(entities);

            if (autoSave)
            {
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false)
        {
            var savedEntity = DbSet.Add(entity).Entity;

            if (autoSave)
            {
                await DbContext.SaveChangesAsync();
            }

            return savedEntity;
        }

        public TEntity Update(TEntity entity, bool autoSave = false)
        {
            DbContext.Attach(entity);

            var updatedEntity = DbContext.Update(entity).Entity;

            if (autoSave)
            {
                DbContext.SaveChanges();
            }

            return updatedEntity;
        }

        public void Update(IEnumerable<TEntity> entities, bool autoSave = false)
        {
            DbSet.UpdateRange(entities);
            if (autoSave)
            {
                DbContext.SaveChanges();
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false)
        {
            DbContext.Attach(entity);

            var updatedEntity = DbContext.Update(entity).Entity;

            if (autoSave)
            {
                await DbContext.SaveChangesAsync();
            }

            return updatedEntity;
        }

        public void Delete(TEntity entity, bool autoSave = false)
        {
            DbSet.Remove(entity);

            if (autoSave)
            {
                DbContext.SaveChanges();
            }
        }

        public async Task DeleteAsync(TEntity entity, bool autoSave = false)
        {
            DbSet.Remove(entity);

            if (autoSave)
            {
                await DbContext.SaveChangesAsync();
            }
        }

        public long GetCount()
        {
            return DbSet.LongCount();
        }

        public async Task<long> GetCountAsync()
        {
            return await DbSet.LongCountAsync();
        }

        protected IQueryable<TEntity> GetQueryable()
        {
            return DbSet.AsQueryable();
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate, bool autoSave = false)
        {
            foreach (var entity in GetQueryable().Where(predicate).ToList())
            {
                Delete(entity, autoSave);
            }

            if (autoSave)
            {
                DbContext.SaveChanges();
            }
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = false)
        {
            var entities = await GetQueryable()
                .Where(predicate)
                .ToListAsync();

            foreach (var entity in entities)
            {
                DbSet.Remove(entity);
            }

            if (autoSave)
            {
                await DbContext.SaveChangesAsync();
            }
        }

      

//        public virtual List<TEntity> SearchWithFilters(
//            int pageNumber,
//            int pageSize,
//            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
//            IEnumerable<Expression<Func<TEntity, bool>>> filters = null,
//            params Expression<Func<TEntity, object>>[] includes)
//        {
//            var query = TableNoTracking;

//            if (filters != null && filters.Count() > 0)
//            {
//                foreach (var filter in filters)
//                {
//                    query = query.Where(filter);
//                }
//            }

//            query = query.IncludeMultiple(includes);


//            if (orderBy != null)
//            {
//                query = orderBy(query);
//            }
//            else
//            {
//                throw new Exception();
//            }

//            return new List<TEntity>(query);
//        }


//        public virtual List<TResult> SearchAndSelectWithFilters<TResult>(
//            int pageNumber,
//            int pageSize,
//            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
//            Expression<Func<TEntity, TResult>> selectors,
//            IEnumerable<Expression<Func<TEntity, bool>>> filters = null,
//          params Expression<Func<TEntity, object>>[] includes
//        )
//        {
//            var query = TableNoTracking;

//            if (filters != null && filters.Any())
//            {
//                foreach (var filter in filters)
//                {
//                    query = query.Where(filter);
//                }
//            }
//            if (includes != null)
//                query = query.IncludeMultiple(includes);
//            if (orderBy != null)
//                query = orderBy(query);

//            var queryList = query.Select(selectors);

//            return new List<TResult>(queryList);
//        }
//        public virtual List<TResult> SearchAndSelectWithFilters<TResult>(
//    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
//    Expression<Func<TEntity, TResult>> selectors,
//    IEnumerable<Expression<Func<TEntity, bool>>> filters = null,
//  params Expression<Func<TEntity, object>>[] includes
//)
//        {
//            var query = TableNoTracking;

//            if (filters != null && filters.Any())
//            {
//                foreach (var filter in filters)
//                {
//                    query = query.Where(filter);
//                }
//            }
//            if (includes != null)
//                query = query.IncludeMultiple(includes);

//            query = orderBy(query);

//            var queryList = query.Select(selectors);

//            return queryList.ToList();
//        }
        public virtual TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual void Delete(object id, bool autoSave = false)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                return;
            }

            Delete(entity, autoSave);
        }

        public virtual async Task DeleteAsync(object id, bool autoSave = false)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
            {
                return;
            }

            await DeleteAsync(entity, autoSave);
        }

    
    }

}



