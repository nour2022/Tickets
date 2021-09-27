using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tickets.Application.Services;
using Tickets.Domain.Entities;
using Tickets.Domain.Tickets.Entities;

namespace Tickets.Web.Pages.Ticket_Pages
{
    [Authorize(policy: "TeamUserAccess")]
   
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public TicketAppService _ticketAppService { get; set; }

        [BindProperty]
        public Ticket Ticket { get; set; }
        public List<Attachment> Attachments;
        
        public DetailsModel(TicketAppService ticketAppService)
        {
            _ticketAppService = ticketAppService;

        }
        public void OnGet(int id)
        {

            Ticket = _ticketAppService.GetById(id,User);
            if (Ticket == null)
            {
                RedirectToPage("../Account/AccessDenied");
            }
            Ticket.Project = _ticketAppService.GetTicketProject(Ticket);
          
            Attachments = new List<Attachment>();
            Attachments =_ticketAppService.GetTicketAttachments(Ticket);
            
        }
    }
}
