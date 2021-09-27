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
    [Authorize(policy: "ManagerAccess")]
    public class DeleteModel : PageModel
    {
        private ProjectAppService _projectAppService;

        [BindProperty]
        public ProjectDto Project { get; set; }
        public DeleteModel(ProjectAppService projectAppService)
        {
            _projectAppService = projectAppService;
        }
        public void OnGet(int id)
        {
            Project = _projectAppService.Find(id);
        }
        public IActionResult OnPost(int id)
        {
            _projectAppService.Delete(id);
            _projectAppService.Commit();
            return RedirectToPage("./Index");
        }
    }
}
