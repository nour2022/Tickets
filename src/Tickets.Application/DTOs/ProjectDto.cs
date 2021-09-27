using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Application.DTOs
{
   public class ProjectDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ProjectStatusDto ProjectType { get; set; }
        public string ClientName { get; set; }
       
       
    }
}
