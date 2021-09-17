using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tickets.Application.Services;
using Tickets.Domain.Entities;
using Tickets.Domain.Projects.Entities;
using Tickets.Domain.Tickets.Entities;

namespace Tickets.Web.Pages.Ticket_Pages
{
    public class CreateModel : PageModel
    {
        private TicketAppService _ticketAppService;
     //   private AttachmentAppService attachmentAppService;
        private TicketAttachmentAppService ticketAttachmentAppService;

        [BindProperty]
        public Ticket Ticket { get; set; }
        public TicketAttachment TicketAttachment { get; set; }
        public List<Project> Projects { get; private set; }
        public IFormFile File { get; set; }
        private readonly IHostingEnvironment hosting;

        public CreateModel(TicketAppService ticketAppService,
                            IHostingEnvironment _hosting,
                            //AttachmentAppService _attachmentAppService,
                            TicketAttachmentAppService _ticketAttachmentAppService)
        {
            _ticketAppService = ticketAppService;
            Ticket = new Ticket();
            Projects = _ticketAppService.SelectAllProjects();
            hosting = _hosting;
          //  attachmentAppService = _attachmentAppService;
            ticketAttachmentAppService = _ticketAttachmentAppService;
        }

        public void OnGet()
        {

           

        }
        public void OnPost()
        {
            string fullPath = string.Empty;
            if (File != null)
            {
                fullPath = getImgUrl();
                //Attachment attachment = new Attachment()
                //{
                //    Path = fullPath,
                //    Name = File.Name,
                //    Type = "Image",
                //    CreatedOn = DateTime.Now,
                //    Extention = File.ContentType
                //};
                //attachmentAppService.Insert(attachment);
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

                _ticketAppService.Insert(Ticket);
                _ticketAppService.Commit();


            }
          
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
