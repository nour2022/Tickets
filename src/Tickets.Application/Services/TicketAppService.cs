using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tickets.Domain.Projects.Entities;
using Tickets.Domain.Tickets.Entities;
using Tickets.Infrastrucure.Data;

namespace Tickets.Application.Services
{
    class TicketAppService : IAppService<Ticket>
    {
        public TicketsDbContext DbContext { get; set; }
        public TicketAppService(TicketsDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public bool Commit()
        {
            if (DbContext.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public bool Delete(int id)
        {
            var ticket = GetById(id);
            return Delete(ticket);
        }

        public bool Delete(Ticket entity)
        {
           var projectTicket= DbContext.Projects.FirstOrDefault(t => t.Tickets.FirstOrDefault(s => s.Id == entity.Id) != null);
            if(projectTicket != null)
            {
                DbContext.Projects.FirstOrDefault(s => s.Tickets.Remove(entity));
            }
            DbContext.Tickets.Remove(entity);
            return true;
        }

        public List<Ticket> GetAll()
        {
            return DbContext.Tickets.ToList();
        }

        public Ticket GetById(int id)
        {
            return DbContext.Tickets.FirstOrDefault(t => t.Id == id);
        }

        public void Insert(Ticket entity)
        {
            var currentUser = DbContext.Users.Find(ClaimTypes.Name);
            entity.CreatedBy = currentUser.FullName;
            entity.CreatedOn = DateTime.Now;

            DbContext.Tickets.Add(entity);
        }

        public void Update(int id)
        {
            var ticket = GetById(id);
            Update(ticket);
        }

        public void Update(Ticket entity)
        {
            DbContext.Update(entity);
        }
    }
}
