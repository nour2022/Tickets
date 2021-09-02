using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Infrastrucure.Data
{
    class TicketsDbContext: DbContext
    {
        public TicketsDbContext(DbContextOptions<TicketsDbContext> options) :base(options)
        {

        }
    }
}
