using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tickets.Domain.Entities.UserEntity;

namespace Tickets.Web.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        [BindProperty]
        public User User { get; set; }
        public LoginModel(UserManager<User> userManager,
                           SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl= null)
        {
            if (ModelState.IsValid)
            {
               var identityResult = await signInManager.PasswordSignInAsync(User.Email, User.PasswordHash, false, false);
                if (identityResult.Succeeded)
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
