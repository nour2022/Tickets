using System.Collections.Generic;
using Tickets.Domain.Lookups.Entities;
using Tickets.Domain.Tickets.Entities;

namespace Tickets.Domain.Projects.Entities
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
