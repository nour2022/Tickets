    public interface IRepository<TEntity> : IRepositoryBase<IAppDbContext, TEntity> where TEntity : class
    {
    }
