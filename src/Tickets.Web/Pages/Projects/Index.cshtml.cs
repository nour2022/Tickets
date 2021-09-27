using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tickets.Application.DTOs;
using Tickets.Application.Services;
using Tickets.Domain.Projects.Entities;
using Tickets.Infrastrucure.Data;

namespace Tickets.Web.Pages.Projects
{
    [Authorize(policy: "TeamAccess")]
    public class IndexModel : PageModel
    {
        private ProjectAppService _projectAppService;
        public IndexModel(ProjectAppService projectAppService)
        {
            _projectAppService = projectAppService;
        }
        public List<ProjectDto> projects { get; set; }
        public void OnGet()
        {
            projects = _projectAppService.GetAll();
          
        }
    }
}
