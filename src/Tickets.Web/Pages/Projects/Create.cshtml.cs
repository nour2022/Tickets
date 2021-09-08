using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tickets.Application.Services;
using Tickets.Domain.Projects.Entities;
using Tickets.Infrastrucure.Data;

namespace Tickets.Web.Pages.Projects
{
   public enum StatusType
    {
        [Display(Name = "Not Started")]
        Not_Started = 1,
        [Display(Name = "In progress")]
        In_Progress = 2,
        [Display(Name = "Finished")]
        Finished = 3,
        [Display(Name = "Cancelled")]
        Cancelled = 4
            
    }
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
