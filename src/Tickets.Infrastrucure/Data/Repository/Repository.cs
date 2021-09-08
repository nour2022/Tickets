 public class Repository<TEntity> : RepositoryBase<IAppDbContext, TEntity>, IRepository<TEntity> where TEntity : class
    {
        public Repository(IAppDbContext dbContext) : base(dbContext)
        {
        }

    }