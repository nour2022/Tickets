using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.Domain.Lookups.Entities;
using Tickets.Infrastrucure.Helpers;

namespace Tickets.Infrastrucure.Mapping.LookUps
{
    class TicketTypeMapping : EntityTypeConfiguration<TicketType>
    {
        public override void Configure(EntityTypeBuilder<TicketType> entity)
        {
            entity.ToTable("TicketType", "lookups");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Type).IsRequired().HasMaxLength(256);
        }
    }
}
