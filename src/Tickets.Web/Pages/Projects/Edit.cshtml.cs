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
    public class EditModel : PageModel
    {
        private ProjectAppService _projectAppService;

        [BindProperty]
        public ProjectDto Project { get; set; }
       
        public EditModel(ProjectAppService projectAppService)
        {
            _projectAppService = projectAppService;
        }
        public void OnGet(int id)
        {
            Project = _projectAppService.Find(id,User);
            if (Project == null)
            {
                RedirectToPage("../Account/AccessDenied");
            }
        }
        public IActionResult OnPost(int id)
        {

            _projectAppService.Update(Project, id,User);
          
            return RedirectToPage("./Index");
        }
    }
}
