using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.Domain.Lookups.Entities;
using Tickets.Infrastrucure.Helpers;

namespace Tickets.Infrastrucure.Mapping.LookUps
{
    public class PriorityMapping : EntityTypeConfiguration<Priority>
    {

        public override void Configure(EntityTypeBuilder<Priority> entity)
        {
            entity.ToTable("Priority", "lookups");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Type).IsRequired().HasMaxLength(256);
        }
    }
}
