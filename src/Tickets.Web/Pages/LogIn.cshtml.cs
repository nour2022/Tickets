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
    public class LogInModel : PageModel
    {
        public UserAppService userAppService { get; set; }
        [BindProperty]
        public UserRegistration User { get; set; }
        public LogInModel(UserAppService _userAppService)
        {
            userAppService = _userAppService;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl= null)
        {
            if (ModelState.IsValid)
            {
                var identityResult = userAppService.LogIn(User);
                if (identityResult.Result.Succeeded)
                {
                    if (returnUrl == null || returnUrl == "/")
                    {
                        return RedirectToPage("Index");

                    }
                    else
                    {
                        return RedirectToPage(returnUrl);
                    }

                }
                ModelState.AddModelError("", "Email or Password is incorrect!");
            }
            return Page();
        }
    }
}
