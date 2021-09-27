using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tickets.Application.DTOs;
using Tickets.Application.Services;
using Tickets.Domain.Entities.UserEntity;

namespace Tickets.Web.Pages
{
    [Authorize(policy: "AdminAccess")]
    public class CreateModel : PageModel
    {
        private readonly RoleAppService roleAppService;

        private UserAppService userAppService { get; set; }
        [BindProperty]
        public UserRegistration User { get; set; }
        [BindProperty]
        public int roleId { get; set; }
        [BindProperty]
        public List<RoleDto> Roles { get; set; }
        public CreateModel(UserAppService _userAppService , RoleAppService roleAppService)
        {
            userAppService = _userAppService;
            this.roleAppService = roleAppService;
        }
        public void OnGet()
        {
            Roles = roleAppService.GetAll();
        }
        public async Task<IActionResult> OnPostAsync()
        {
           
           var result = userAppService.Insert(User,roleId);

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
