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

namespace Tickets.Web.Pages.Projects
{
    [Authorize(policy: "UserAccess")]
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public ProjectAppService _projectAppService { get; set; }
       
        [BindProperty]
        public ProjectDto Project { get; set; }
       
        public DetailsModel(ProjectAppService projectAppService)
        {
            _projectAppService = projectAppService;
        }
        public void OnGet(int id)
        {
            Project = _projectAppService.Find(id);
        }
        
    }
}
