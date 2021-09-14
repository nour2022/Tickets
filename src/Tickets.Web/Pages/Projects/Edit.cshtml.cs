using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tickets.Application.Services;
using Tickets.Domain.Entities;
using Tickets.Domain.Projects.Entities;

namespace Tickets.Web.Pages.Projects
{
    public class EditModel : PageModel
    {
        private ProjectAppService _projectAppService;

        [BindProperty]
        public Project Project { get; set; }
        public StatusType StatusType { get; set; }
        public EditModel(ProjectAppService projectAppService)
        {
            _projectAppService = projectAppService;
        }
        public void OnGet(int id)
        {
            Project = _projectAppService.GetById(id);
        }
        public void OnPost(int id)
        {

            _projectAppService.Update(Project, id);
            _projectAppService.Commit();
        }
    }
}
