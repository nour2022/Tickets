using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Tickets.Infrastrucure.Data.Repository
{
    public interface IRepositoryBase<TContext, TEntity>
        where TContext : TicketsDbContext
        where TEntity : class
    {
        IQueryable<TEntity> Table { get; }

        IQueryable<TEntity> TableNoTracking { get; }


        //================================================================
        //============================ INSERT ============================
        //================================================================
        
        TEntity Insert(TEntity entity, bool autoSave = false);
       
        Task<TEntity> InsertAsync( TEntity entity, bool autoSave = false);

        Task InsertAsync(IEnumerable<TEntity> entities, bool autoSave = false);
        void Insert(IEnumerable<TEntity> entities, bool autoSave = false);


        //================================================================
        //============================ UPDATE ============================
        //================================================================

       
        TEntity Update( TEntity entity, bool autoSave = false);
       
        Task<TEntity> UpdateAsync( TEntity entity, bool autoSave = false);
        void Update(IEnumerable<TEntity> entities, bool autoSave = false);


        //================================================================
        //============================ DELETE ============================
        //================================================================

        void Delete( TEntity entity, bool autoSave = false);
        void Delete( Expression<Func<TEntity, bool>> predicate, bool autoSave = false);
        Task DeleteAsync( TEntity entity, bool autoSave = false);
        Task DeleteAsync( Expression<Func<TEntity, bool>> predicate, bool autoSave = false);

        long GetCount();

        Task<long> GetCountAsync();

        //List<TEntity> SearchWithFilters(
        //        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
        //        IEnumerable<Expression<Func<TEntity, bool>>> filters = null,
        //        params Expression<Func<TEntity, object>>[] includes);

    //   List<TEntity> SearchWithFilters(
    //        int pageNumber,
    //        int pageSize,
    //        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
    //        IEnumerable<Expression<Func<TEntity, bool>>> filters = null,
    //        params Expression<Func<TEntity, object>>[] includes);

    //    List<TResult> SearchAndSelectWithFilters<TResult>(
    //        int pageNumber,
    //        int pageSize,
    //        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
    //        Expression<Func<TEntity, TResult>> selectors,
    //        IEnumerable<Expression<Func<TEntity, bool>>> filters = null,
    //       params Expression<Func<TEntity, object>>[] includes
    //    );
    //    List<TResult> SearchAndSelectWithFilters<TResult>(
    //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
    //    Expression<Func<TEntity, TResult>> selectors,
    //    IEnumerable<Expression<Func<TEntity, bool>>> filters = null,
    //   params Expression<Func<TEntity, object>>[] includes
    //);

        void Delete(object id, bool autoSave = false);
        Task DeleteAsync(object id, bool autoSave = false);

        
        TEntity GetById(object id);
        
        Task<TEntity> GetByIdAsync(object id);

    }

}
