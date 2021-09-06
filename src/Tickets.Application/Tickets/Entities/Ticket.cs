using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Entities.UserEntity;
using Tickets.Application.Lookups.Entities;
using Tickets.Application.Projects.Entities;

namespace Tickets.Application.Tickets.Entities
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
