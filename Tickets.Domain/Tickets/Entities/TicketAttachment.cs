using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Domain;
using Tickets.Domain.Entities;

namespace Tickets.Domain.Tickets.Entities
{
    public class TicketAttachment : EntityBase
    {
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public int AttachmentId { get; set; }
        public Attachment Attachment { get; set; }

    }
}
