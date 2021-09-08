using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.Domain.Lookups.Entities;
using Tickets.Infrastrucure.Helpers;

namespace Tickets.Infrastrucure.Mapping.LookUps
{
    class TicketStateMapping : EntityTypeConfiguration<TicketState>
    {
        public override void Configure(EntityTypeBuilder<TicketState> entity)
        {
            entity.ToTable("TicketState", "lookups");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Type).IsRequired().HasMaxLength(256);
        }
    }
}
