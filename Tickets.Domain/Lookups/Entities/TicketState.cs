using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Domain;
using Tickets.Domain.Tickets.Entities;

namespace Tickets.Domain.Lookups.Entities
{
    public class TicketState : EntityBase<int>
    {

        public string Type { get; set; }
        public List<Ticket> Tickets { get; set; }


    }
}
