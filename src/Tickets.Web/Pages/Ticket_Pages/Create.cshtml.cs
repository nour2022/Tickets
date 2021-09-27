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
using Tickets.Domain.Entities;
using Tickets.Domain.Projects.Entities;
using Tickets.Domain.Tickets.Entities;

namespace Tickets.Web.Pages.Ticket_Pages
{
    [Authorize(policy: "TeamUserAccess")]
    public class CreateModel : PageModel
    {
        private TicketAppService _ticketAppService;
   
        private TicketAttachmentAppService ticketAttachmentAppService;

        [BindProperty]
        public Ticket Ticket { get; set; }
        public TicketAttachment TicketAttachment { get; set; }
        public List<ProjectDto> Projects { get; private set; }
        public IFormFile File { get; set; }
        private readonly IHostingEnvironment hosting;
        private readonly ProjectAppService projectAppService;

        public CreateModel(TicketAppService ticketAppService,
                            IHostingEnvironment _hosting,
                            ProjectAppService projectAppService,
                            TicketAttachmentAppService _ticketAttachmentAppService)
        {
            _ticketAppService = ticketAppService;
            Ticket = new Ticket();
           
            hosting = _hosting;
            this.projectAppService = projectAppService;
           
            ticketAttachmentAppService = _ticketAttachmentAppService;
        }

        public void OnGet()
        {
            Projects = projectAppService.GetAll();


        }
        public IActionResult OnPost()
        {
            
            if (File != null)
            {
                string fullPath = getImgUrl();
                Ticket.TicketAttachment = new List<TicketAttachment>
                {
                    new TicketAttachment
                    {
                        Attachment = new Attachment()
                        {
                            Path = fullPath,
                            Name = File.FileName,
                            Type = "Image",
                            CreatedOn = DateTime.Now,
                            Extention = File.ContentType
                        }
                    }
                };

               


            }
            _ticketAppService.Insert(Ticket,User);
            _ticketAppService.Commit();
            return RedirectToPage("./Index");

        }
       private string getImgUrl()
        {
            string upload = Path.Combine(hosting.WebRootPath, "Ref");
            string fileName = File.FileName;
            string fullPath = Path.Combine(upload, fileName);
          File.CopyTo(new FileStream(fullPath, FileMode.Create));
            return fullPath;
        }
    }
}
