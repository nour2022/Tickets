using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Projects.Entities;

namespace Tickets.Infrastrucure.Mapping.Projects
{
    class ProjectTeamMapping : IEntityTypeConfiguration<ProjectTeam>
    {
       

            public void Configure(EntityTypeBuilder<ProjectTeam> entity)
            {
                entity.ToTable("ProjectTeam", "project_teams");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.RoleId).IsRequired();

            }
    }
}
