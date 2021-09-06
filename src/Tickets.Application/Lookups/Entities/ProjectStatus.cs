using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Projects.Entities;

namespace Tickets.Application.Lookups.Entities
{
    public class ProjectStatus : EntityBase<int>
    {
      
        public string Status { get; set; }
        public List<Project> Projects { get; set; }
    }
}
