using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tickets.Application.DTOs;
using Tickets.Application.Services;

namespace Tickets.Web.Pages.User_Pages
{
    [Authorize(policy: "AdminAccess")]
    public class DeleteModel : PageModel
    {
        private readonly UserAppService userAppService;
        [BindProperty]
        public UserDto user { get; set; }
        public DeleteModel(UserAppService _userAppService)
        {
            userAppService = _userAppService;
        }
        public void OnGet( int id )
        {
            user = userAppService.Find(id,User);
            if(user == null)
            {
                RedirectToPage("../Account/AccessDenied");
            }
        }
        public IActionResult OnPost(int id)
        {
            userAppService.Remove(id);
            return RedirectToPage("./Index");
        }
    }
}
