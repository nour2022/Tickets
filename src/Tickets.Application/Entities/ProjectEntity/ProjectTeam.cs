using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Application.Entities
{
    class ProjectTeam
    {
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public int JobTitleId { get; set; }
    }
}
