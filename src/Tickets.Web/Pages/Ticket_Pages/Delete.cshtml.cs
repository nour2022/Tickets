using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tickets.Application.Services;
using Tickets.Domain.Tickets.Entities;

namespace Tickets.Web.Pages.Ticket_Pages
{
    [Authorize(policy: "TeamUserAccess")]
   
    public class DeleteModel : PageModel
    {
        public TicketAppService _ticketAppService;
        
        [BindProperty]
        public Ticket Ticket { get; set; }
        public DeleteModel(TicketAppService ticketAppService)
        {
            _ticketAppService = ticketAppService;
            Ticket = new Ticket();
        }
        public void OnGet(int id)
        {
            Ticket = _ticketAppService.GetById(id);
        }
        public IActionResult OnPost(int id)
        {
          var isDeleted= _ticketAppService.Delete(id, User);
           if(!isDeleted)
            {
                return RedirectToPage("./Account/AccessDenied");
            }
            return RedirectToPage("./Index");
        }
    }
}
