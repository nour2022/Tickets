using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tickets.Application.Services;
using Tickets.Domain.Entities;
using Tickets.Domain.Projects.Entities;

namespace Tickets.Web.Pages.Projects
{

    public class CreateModel : PageModel
    {
        private ProjectAppService _projectAppService;
       
        public StatusType StatusType { get; set; }
        [BindProperty]
        public Project project { get; set; }
     
        public CreateModel(ProjectAppService projectAppService)
        {
            _projectAppService = projectAppService;
        }

        public void OnGet()
        {
           
           
            
        }
        public void OnPost()
        {
            _projectAppService.Insert(project);
            _projectAppService.Commit();
        }
    }
}
