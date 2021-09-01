using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Application.Entities
{
    class TicketIssue
    {
        public int Id { get; set; }
        public Issue Issue { get; set; }
    }
}
