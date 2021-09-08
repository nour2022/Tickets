using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tickets.Application.Services;
using Tickets.Domain.Projects.Entities;

namespace Tickets.Web.Pages.Projects
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public ProjectAppService _projectAppService { get; set; }
       
        [BindProperty]
        public Project Project { get; set; }
       
        public DetailsModel(ProjectAppService projectAppService)
        {
            _projectAppService = projectAppService;
        }
        public void OnGet(int id)
        {
            Project = _projectAppService.GetById(id);
        }
        
    }
}
