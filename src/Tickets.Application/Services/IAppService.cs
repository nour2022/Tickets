using System.Collections.Generic;
using Tickets.Domain.Projects.Entities;

namespace Tickets.Application.Services
{
    public interface IAppService<TEntity>
        where TEntity : class
    {
        bool Commit();
        bool Delete(int id);
        bool Delete(TEntity entity);
        List<TEntity> GetAll();
        TEntity GetById(int id);
        void Insert(TEntity entity);
        void Update(int id);
        void Update(TEntity entity);
    }
}