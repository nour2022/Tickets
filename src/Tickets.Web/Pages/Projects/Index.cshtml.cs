using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tickets.Application.Services;
using Tickets.Domain.Projects.Entities;
using Tickets.Infrastrucure.Data;

namespace Tickets.Web.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private ProjectAppService _projectAppService;
        public IndexModel(ProjectAppService projectAppService)
        {
            _projectAppService = projectAppService;
        }
        public List<Project> projects { get; set; }
        public void OnGet()
        {
            projects = _projectAppService.GetAll();
          
        }
    }
}
