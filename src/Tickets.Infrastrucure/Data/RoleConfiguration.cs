using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Domain.Entities.UserEntity;
using Tickets.Infrastrucure.Helpers;

namespace Tickets.Infrastrucure.Data
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
            builder.HasData(new Role
            {
                Id = 2,
                Name = "Manger",
                NormalizedName = "MANAGER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
            builder.HasData(new Role
            {
                Id = 3,
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
        }
    }
}
