using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tickets.Application.DTOs;
using Tickets.Application.Services;

namespace Tickets.Web.Pages.User_Pages
{
    public class EditModel : PageModel
    {
        private readonly UserAppService userAppService;
        [BindProperty]
        public UserDto User { get; set; }
        public IFormFile File { get; set; }
        private readonly IHostingEnvironment hosting;
        public EditModel(UserAppService userAppService,  IHostingEnvironment _hosting)
        {
            User = new UserDto();
            hosting = _hosting;
            this.userAppService = userAppService;
        }
        public void OnGet(int id)
        {
            User = userAppService.Find(id);
        }
        public void OnPost(int id)
        {
            if(File != null)
            {
                var userDto = userAppService.Find(id);
                string upload = Path.Combine(hosting.WebRootPath, "Ref");
                string oldImage = userDto.ProfileImage;
                string fullPath = Path.Combine(upload, oldImage);
                System.IO.File.Delete(fullPath);
               
                User.ProfileImage = getImgUrl();
            }
            userAppService.Edit(User, id);
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
