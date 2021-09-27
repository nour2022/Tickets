using System.Collections.Generic;
using System.Security.Claims;
using Tickets.Domain.Projects.Entities;

namespace Tickets.Application.Services
{
    public interface IAppService<TEntity>
        where TEntity : class
    {
        bool Commit();
        bool Delete(int id);
      
        List<TEntity> GetAll();
        TEntity GetById(int id);
        void Insert(TEntity entity, ClaimsPrincipal user);
        void Update(int id,ClaimsPrincipal user);
       
    }
}