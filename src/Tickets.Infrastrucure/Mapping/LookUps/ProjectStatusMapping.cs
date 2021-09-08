using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.Domain.Lookups.Entities;
using Tickets.Infrastrucure.Helpers;

namespace Tickets.Infrastrucure.Mapping.LookUps
{
    class ProjetStatusMapping : EntityTypeConfiguration<ProjectStatus>
    {
     
        public override void Configure(EntityTypeBuilder<ProjectStatus> entity)
        {
            entity.ToTable("ProjetStatus", "lookups");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Status).IsRequired().HasMaxLength(256);
        }
    }
}
