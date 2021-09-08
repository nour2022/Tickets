using System;

namespace Tickets.Domain.Projects.Entities
{
    public class ProjectTeam : EntityBase<int>
    {

        public Project Project { get; set; }
        public int UserId { get; set; }
        public Guid RoleId { get; set; }
        public int ProjectId { get; set; }
    }
}
