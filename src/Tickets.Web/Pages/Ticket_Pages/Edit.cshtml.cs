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
using Tickets.Application.Services;
using Tickets.Domain.Entities;
using Tickets.Domain.Tickets.Entities;

namespace Tickets.Web.Pages.Ticket_Pages
{
    [Authorize(policy: "TeamAccess")]
    public class EditModel : PageModel
    {
        private TicketAppService _ticketAppService;
        private TicketAttachmentAppService _ticketAttachmenAppService;
        [BindProperty]
        public Ticket Ticket { get; set; }
        public IFormFile File { get; set; }
        private readonly IHostingEnvironment hosting;
        public EditModel(TicketAppService ticketAppService, 
            TicketAttachmentAppService ticketAttachmenAppService, 
            IHostingEnvironment _hosting)
        {
            _ticketAppService = ticketAppService;
            _ticketAttachmenAppService = ticketAttachmenAppService;
            hosting = _hosting;

        }
        public void OnGet(int id)
        {
            Ticket = _ticketAppService.GetById(id,User);
            if(Ticket == null)
            {
                RedirectToPage("../Account/AccessDenied");
            }
        }
        public void OnPost(int id)
        {
            if(File != null)
            {
                Ticket = _ticketAppService.GetById(id,User);

                string path = getImgUrl();
                Ticket.TicketAttachment = new List<TicketAttachment>
                {
                    new TicketAttachment
                    {
                        Attachment = new Attachment()
                        {
                            Path =  path,
                            Name = File.FileName,
                            Type = "Image",
                            CreatedOn = DateTime.Now,
                            Extention = File.ContentType
                        }
                    }
                };
            }
            _ticketAppService.Update(Ticket, id,User);
            RedirectToPage("./Index");
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
