using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tickets.Application.Services;
using Tickets.Domain.Tickets.Entities;

namespace Tickets.Web.Pages.Ticket_Pages
{
    public class DeleteModel : PageModel
    {
        public TicketAppService _ticketAppService;

        [BindProperty]
        public Ticket Ticket { get; set; }
        public DeleteModel(TicketAppService ticketAppService)
        {
            _ticketAppService = ticketAppService;
        }
        public void OnGet(int id)
        {
            Ticket = _ticketAppService.GetById(id);
        }
        public void OnPost(int id)
        {
            _ticketAppService.Delete(id);
            _ticketAppService.Commit();

        }
    }
}
