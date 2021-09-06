using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Tickets.Entities;

namespace Tickets.Application.Lookups.Entities
{
    public class TicketType : EntityBase<int>
    {
      
        public string Type { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
