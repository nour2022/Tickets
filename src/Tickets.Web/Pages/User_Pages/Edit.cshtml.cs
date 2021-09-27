using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tickets.Application.DTOs;
using Tickets.Application.Services;

namespace Tickets.Web.Pages.User_Pages
{
    [Authorize(policy: "TeamUserAccess")]
    public class EditModel : PageModel
    {
        private readonly UserAppService userAppService;
        [BindProperty]
        public UserDto user { get; set; }
        public IFormFile File { get; set; }
        private readonly IHostingEnvironment hosting;
        public EditModel(UserAppService userAppService,  IHostingEnvironment _hosting)
        {
            user = new UserDto();
            hosting = _hosting;
            this.userAppService = userAppService;
        }
        public void OnGet(int id)
        {
            user = userAppService.Find(id,User);
            if(user == null)
            {
                RedirectToPage("../Acount/AccessDenied");
            }
        }
        public void OnPost(int id)
        {
            
            if (File != null)
            {
                var userDto = userAppService.Find(id,User);
                string upload = Path.Combine(hosting.WebRootPath, "Ref");
                string oldImage = userDto.ProfileImage;
                string fullPath = Path.Combine(upload, oldImage);
                System.IO.File.Delete(fullPath);
               
                user.ProfileImage = getImgUrl();
            }
            
            userAppService.Edit(user, id);
        //    return RedirectToPage("./Details",id);
        }
        private string getImgUrl()
        {
            string upload = Path.Combine(hosting.WebRootPath, "Ref");
            string fileName = File.FileName;
            string fullPath = Path.Combine(upload, fileName);
            File.CopyTo(new FileStream(fullPath, FileMode.Create));
            return fileName;
        }
    }
}
