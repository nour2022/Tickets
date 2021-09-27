using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Domain.Tickets.Entities;

namespace Tickets.Application.DTOs
{
   public class TicketDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PriorityDto Priority { get; set; }
        public TicketStateDto TicketState { get; set; }
        public TicketTypeDto TicketType { get; set; }
        public ProjectDto Project { get; set; }
        public List<TicketAttachment> TicketAttachments { get; set; }
    }
}
