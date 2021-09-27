using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Application.Services;
using Tickets.Domain.Tickets.Entities;

namespace Tickets.Web.Pages
{
    [Authorize(policy:"UserAccess")]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public TicketAppService ticketAppService { get; set; }
        public ProjectAppService projectAppService { get; set; }
        public UserAppService UserAppService { get; set; }
        public int TicketCount { get; set; }
        public int ProjectCount { get; set; }
        public int UserCount { get; set; }
        public double TicketCompleted { get; set; }
        public IndexModel(ILogger<IndexModel> logger , 
            TicketAppService appService,
            UserAppService userAppService,
            ProjectAppService _projectAppService)
        {
            _logger = logger;
            ticketAppService = appService;
            projectAppService = _projectAppService;
            UserAppService = userAppService;
        }

        public void OnGet()
        {
            TicketCount = ticketAppService.GetAll().Count;
            ProjectCount = projectAppService.GetAll().Count;
            UserCount = UserAppService.GetAllUsers().Count;
            TicketCompleted = AvgTicketCompleted(Convert.ToDouble(TicketCount));
        }
        public double AvgTicketCompleted(double count)
        {
            double closedTickets = ticketAppService.GetAll().Where(e=>e.StateId==4).Count();
            double res = (closedTickets / count) ;
            return res * 100;
        }
    }
}
