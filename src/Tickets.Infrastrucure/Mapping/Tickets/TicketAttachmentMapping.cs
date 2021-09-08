using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tickets.Domain.Tickets.Entities;
using Tickets.Infrastrucure.Helpers;

namespace Tickets.Infrastrucure.Mapping.Tickets
{
    class TicketAttachmentMapping : EntityTypeConfiguration<TicketAttachment>
    {
        public override void Configure(EntityTypeBuilder<TicketAttachment> entity)
        {
            entity.ToTable("TicketAttachment", "tickets");
            entity.HasKey(a => new {a.TicketId, a.AttachmentId});

        }
    }
    }
