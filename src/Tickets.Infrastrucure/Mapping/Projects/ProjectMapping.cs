using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.Application;
using Tickets.Application.Projects.Entities;
using Microsoft.EntityFrameworkCore;
using Tickets.Infrastrucure.Helpers;

namespace Tickets.Infrastrucure.Mapping.Projects
{

    public class ProjectMapping : EntityTypeConfiguration<Project>
    {

        public override void Configure(EntityTypeBuilder<Project> entity)
        {
            entity.ToTable("Project", "projects");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.TypeId).IsRequired();
            entity.Property(e => e.Title).IsRequired().HasMaxLength(256);
            entity.Property(e => e.CreatedOn).IsRequired();
            entity.Property(e => e.CreatedBy).IsRequired().HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);

           
          
            entity.HasMany(e => e.ProjectTeams).WithOne(e => e.Project).HasForeignKey(e => e.ProjectId);
            entity.HasOne(e => e.ProjectType).WithMany(e => e.Projects);
        }
    }
}
