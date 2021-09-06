using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Tickets.Entities;

namespace Tickets.Infrastrucure.Mapping.Tickets
{
    class TicketAttachmentMapping : IEntityTypeConfiguration<TicketAttachment>
    {
        public void Configure(EntityTypeBuilder<TicketAttachment> entity)
        {
            entity.ToTable("TicketAttachment", "tickets");
            

        }
    }
    }
