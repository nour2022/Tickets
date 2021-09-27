using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.DTOs;
using Tickets.Domain.Entities.UserEntity;
using Tickets.Infrastrucure.Data;

namespace Tickets.Application.Services
{
    public class RoleAppService 
    {
        public TicketsDbContext DbContext { get; set; }
        public RoleAppService(TicketsDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public List<RoleDto> GetAll()
        {
            var roles = DbContext.Roles.ToList();
            List<RoleDto> roleDtos = new List<RoleDto>();
            foreach (var role in roles)
            {
                roleDtos.Add(Mapper(role));
            }
            return roleDtos;
        }
        private RoleDto Mapper(Role role)
        {

            var roleDto = new RoleDto()
            {
                Id = role.Id,
                Name = role.Name
            };
            return roleDto;
        }
        public RoleDto GetRole(int UserId)
        {
            var roleId = DbContext.UserRoles.Where(i => i.UserId == UserId).FirstOrDefault().RoleId;
            var role = Find(roleId);
            var roleDto = new RoleDto()
            {
                Id = role.Id,
                Name = role.Name
            };
            return roleDto;
        }

        public Role Find(int roleId)
        {
            return DbContext.Roles.Find(roleId);
        }
    }
    }
