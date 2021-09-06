using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Lookups.Entities;

namespace Tickets.Infrastrucure.Mapping.LookUps
{
    class TicketStateMapping : IEntityTypeConfiguration<TicketState>
    {
        public void Configure(EntityTypeBuilder<TicketState> entity)
        {
            entity.ToTable("TicketState", "lookups");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Type).IsRequired().HasMaxLength(256);
        }
    }
}
