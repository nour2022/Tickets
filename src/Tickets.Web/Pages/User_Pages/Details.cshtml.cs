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
    [Authorize(policy: "TeamUserAccess")]
    public class DetailsModel : PageModel
    {
        private readonly UserAppService userAppService;
        private readonly RoleAppService roleAppService;

        [BindProperty]
        public UserDto user { get; set; }
        [BindProperty]
        public string role { get; set; }
        public DetailsModel(UserAppService userAppService,RoleAppService roleAppService)
        {
            user = new UserDto();

            this.userAppService = userAppService;
            this.roleAppService = roleAppService;
        }
        public void OnGet(int id)
        {
            user = userAppService.Find(id,User);
            if(user == null)
            {
                
                RedirectToPage("../Account/AccessDenied");
            }
            role = roleAppService.GetRole(id).Name;
        }
    }
}
