using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Projects.Entities;
using Tickets.Infrastrucure.Helpers;

namespace Tickets.Infrastrucure.Mapping.Projects
{
    class ProjectTeamMapping : EntityTypeConfiguration<ProjectTeam>
    {
       

            public override void Configure(EntityTypeBuilder<ProjectTeam> entity)
            {
                entity.ToTable("ProjectTeam", "project_teams");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.RoleId).IsRequired();

            }
    }
}
