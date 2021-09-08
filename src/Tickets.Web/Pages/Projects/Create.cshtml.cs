using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tickets.Infrastrucure.Data;

namespace Tickets.Web.Pages.Projects
{
    public class CreateModel : PageModel
    {
       
        public CreateModel()
        {
          
        }
        public IActionResult OnGet()
        {

            return Page();
            
        }
        public void OnPost()
        {

        }
    }
}
