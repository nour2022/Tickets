using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tickets.Application.Services;

namespace Tickets.Web.Pages.User_Pages
{
    public class ResetPasswordModel : PageModel
    {
        private readonly UserAppService userAppService;
        [BindProperty]
        public string inputPasswordOld { get; set; }
        public string inputPasswordNew { get; set; }
        public string inputPasswordNewVerify { get; set; }
        public ResetPasswordModel(UserAppService _userAppService)
        {
            userAppService = _userAppService;
        }
        public void OnGet(int id)
        {
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (inputPasswordNewVerify.Equals(inputPasswordNew))
            {
                ModelState.AddModelError("", "Verify Password should be exactly as new Password!");
            }
            if (ModelState.IsValid)
            {
                var result = userAppService.ChangePassword(inputPasswordNew, inputPasswordOld, id);
                if (!result.Result.Succeeded)
                {
                    foreach (var err in result.Result.Errors)
                    {
                        ModelState.AddModelError(err.Code, err.Description);

                    }
                }
                return RedirectToPage("/Index");
            }

            return Page();
       
        }
    }
}
