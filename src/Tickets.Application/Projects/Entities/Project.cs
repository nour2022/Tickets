using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Entities;
using Tickets.Application.Entities.UserEntity;
using Tickets.Application.Lookups.Entities;
using Tickets.Application.Tickets.Entities;

namespace Tickets.Application.Projects.Entities
{
    public class Project : FullAuditedEntityBase<int>
    {
        public string Title { get; set; }
        public ProjectStatus ProjectType { get; set; }
        public string ClientName { get; set; }
        public int TypeId { get; set; }
        public List<ProjectTeam> ProjectTeams { get; set; }
      
        public List<Ticket> Tickets { get; set; }
    }
}
