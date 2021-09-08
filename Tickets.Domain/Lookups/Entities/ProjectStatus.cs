using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Domain;
using Tickets.Domain.Projects.Entities;

namespace Tickets.Domain.Lookups.Entities
{
    public class ProjectStatus : EntityBase<int>
    {

        public string Status { get; set; }
        public List<Project> Projects { get; set; }
    }
}
