using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tickets.Application.DTOs;
using Tickets.Application.Services;
using Tickets.Domain.Entities.UserEntity;

namespace Tickets.Web.Pages.User_Pages
{
    [Authorize(policy: "AdminAccess")]
    public class IndexModel : PageModel
    {
        private readonly UserAppService userAppService;
        [BindProperty]
        public List<UserDto> Users { get; set; }
        [BindProperty]
        public UserSearchDto User { get; set; } = new UserSearchDto();

        public IndexModel(UserAppService userAppService)
        {
            Users = new List<UserDto>();
           
            this.userAppService = userAppService;
        }
       
        public void OnGet(UserSearchDto user)
        {
         
            if(user.Email != null || user.FullName != null)
            {
                Users = userAppService.Search(user);

            }
            else
            {
                Users = userAppService.GetAllUsers();
            }
          
        }
       

    }
}
