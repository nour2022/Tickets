using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Application.Entities
{
    class Ticket : FullAuditedEntityBase<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TickeIssueId { get; set; }
        public int PriorityId { get; set; }
        public int StateId { get; set; }

    }
}
