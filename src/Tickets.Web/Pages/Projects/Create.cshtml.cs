using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tickets.Application.DTOs;
using Tickets.Application.Services;
using Tickets.Domain.Entities;
using Tickets.Domain.Projects.Entities;

namespace Tickets.Web.Pages.Projects
{
    [Authorize(policy: "TeamAccess")]
    public class CreateModel : PageModel
    {
        private ProjectAppService _projectAppService;
       
        public StatusType StatusType { get; set; }
        [BindProperty]
        public ProjectDto project { get; set; }
     
        public CreateModel(ProjectAppService projectAppService)
        {
            _projectAppService = projectAppService;
        }

        public IActionResult OnPost()
        {
            _projectAppService.Insert(project);
            _projectAppService.Commit();
            return RedirectToPage("./Index");
        }
    }
}
