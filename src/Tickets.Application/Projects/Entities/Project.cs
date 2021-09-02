using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Entities;

namespace Tickets.Application.Projects.Entities
{
   public class Project : FullAuditedEntityBase<int>
    {
        public string Title { get; set; }
        public int StatusId { get; set; }
        public int ClientId { get; set; }
    }
}
