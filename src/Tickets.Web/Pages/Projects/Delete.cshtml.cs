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
    public class DeleteModel : PageModel
    {
        private ProjectAppService _projectAppService;

        [BindProperty]
        public Project Project { get; set; }
        public DeleteModel(ProjectAppService projectAppService)
        {
            _projectAppService = projectAppService;
        }
        public void OnGet(int id)
        {
            Project = _projectAppService.GetById(id);
        }
        public void OnPost(int id)
        {
            _projectAppService.Delete(id);
            _projectAppService.Commit();
                    
        }
    }
}
