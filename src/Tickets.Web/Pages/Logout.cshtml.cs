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
    public class LogoutModel : PageModel
    {
       
        private readonly SignInManager<User> signInManager;
      
       
        public LogoutModel(SignInManager<User> _signInManager)
        {
         
            signInManager = _signInManager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await signInManager.SignOutAsync();
            return RedirectToPage("/LogIn");
        }
        }
}
