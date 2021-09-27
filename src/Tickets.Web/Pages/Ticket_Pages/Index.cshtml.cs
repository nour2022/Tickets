using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Tickets.Application.Services;
using Tickets.Domain.Lookups.Entities;
using Tickets.Domain.Tickets.Entities;

namespace Tickets.Web.Pages.Ticket_Pages
{
    [Authorize(policy: "TeamAccess")]
    public class IndexModel : PageModel
    {
        public TicketAppService _ticketAppService { get; private set; }
        public IndexModel(TicketAppService ticketAppService)
        {
            _ticketAppService = ticketAppService;
        }
        public List<Ticket> tickets { get; set; }
        [BindProperty]
        public Priority priority { get; set; }
        public void OnGet()
        {
            tickets = _ticketAppService.GetAll();

        }
    }
}
