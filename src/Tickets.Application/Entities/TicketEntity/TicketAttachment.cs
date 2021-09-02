using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Application.Entities.TicketEntity
{
    class TicketAttachment
    {
        public int TicketId { get; set; }
        public List<int> AttachmentId { get; set; }

    }
}
