using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tickets.Application.DTOs;
using Tickets.Application.Services;

namespace Tickets.Web.Pages.User_Pages
{
    public class DetailsModel : PageModel
    {
        private readonly UserAppService userAppService;
        [BindProperty]
        public UserDto User { get; set; }
        public DetailsModel(UserAppService userAppService)
        {
            User = new UserDto();

            this.userAppService = userAppService;
        }
        public void OnGet(int id)
        {
            User = userAppService.Find(id);
        }
    }
}
