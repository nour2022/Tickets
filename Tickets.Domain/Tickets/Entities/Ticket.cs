using System.Collections.Generic;
using Tickets.Domain.Lookups.Entities;
using Tickets.Domain.Projects.Entities;

namespace Tickets.Domain.Tickets.Entities
{
    public class Ticket : FullAuditedEntityBase<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TickeTypeId { get; set; }
        public TicketType Type { get; set; }
        public int PriorityId { get; set; }
        public Priority Priority { get; set; }
        public int StateId { get; set; }
        public TicketState State { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public List<TicketAttachment> TicketAttachment { get; set; }


    }
}
