using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Lookups.Entities;

namespace Tickets.Application.Projects.Entities
{
   public class ProjectTeam : EntityBase<int>
    {
       
        public Project Project { get; set; }
        public int UserId { get; set; }
        public Guid RoleId { get; set; }
        public int ProjectId { get; set; }
    }
}
