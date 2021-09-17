using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tickets.Application.DTOs;
using Tickets.Application.Services;
using Tickets.Domain.Entities.UserEntity;

namespace Tickets.Web.Pages
{
    public class CreateModel : PageModel
    {
        

        public UserAppService userAppService { get; set; }
        [BindProperty]
        public UserRegistration User { get; set; }
        public CreateModel(UserAppService _userAppService)
        {
            userAppService = _userAppService;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
           
           var result = userAppService.Insert(User);

            if (!result.Result.Succeeded)
            {
                foreach (var err in result.Result.Errors)
                {
                    ModelState.AddModelError(err.Code,err.Description);

                }
            }
                   
            return RedirectToPage("/Index");
        }
    }
}
