using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tickets.Domain.Entities;
using Tickets.Domain.Lookups.Entities;
using Tickets.Domain.Projects.Entities;
using Tickets.Domain.Tickets.Entities;
using Tickets.Infrastrucure.Data;

namespace Tickets.Application.Services
{
   public class TicketAppService : IAppService<Ticket>
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

        //public bool Delete(int id)
        //{
        //   //var ticket = GetById(id,user);
           
        //  //  return Delete(ticket);
        //}

        public bool Delete(int id, ClaimsPrincipal user)
        {
            var ticket = GetById(id,user);

            var ticketState = GetState(ticket);
            if (IsAuthenticated(user,ticket,ticketState))
                 
            {
                Delete(ticket);
                Commit();
                return true;
            }
            else
            {
                return false;
            }
           
        }

        private bool Delete(Ticket entity)
        {
            DbContext.Tickets.Remove(entity);
            return true;
        }

        public List<Ticket> GetAll()
        {
            return DbContext.Tickets.ToList();
        }

        public Ticket GetById(int id, ClaimsPrincipal user)
        {
            var ticket = DbContext.Tickets.FirstOrDefault(t => t.Id == id);
            if (IsAuthenticated(user, ticket,null))
            {
                return ticket;
            }
            return null;
        }
        public bool IsAuthenticated(ClaimsPrincipal user,Ticket ticket,TicketState? state)
        {
           
            bool IsAuthenticated = user.IsInRole("Admin")
                               || user.IsInRole("Manager")
                               || user.IsInRole("Developer Team");
            bool userAccess=false;
            if (state != null)
            {
                userAccess = (ticket.CreatedBy == user.Identity.Name
                && (state.Id == 1 || state.Id == 4));
            }
            else if(user.IsInRole("User"))
            {
                userAccess = ticket.CreatedBy == user.Identity.Name;
            }
            if (IsAuthenticated || userAccess)
            {
                return true;
            }
            return false;
               
        }
        public void Insert(Ticket entity, ClaimsPrincipal user)
        {
           
            entity.CreatedBy = user.Identity.Name;
            entity.CreatedOn = DateTime.Now;

            DbContext.Tickets.Add(entity);
            Commit();
        }

        public void Update(int id, ClaimsPrincipal user)
        {
            var ticket = GetById(id,user);
            Update(ticket,id,user);
           
        }

        public void Update(Ticket updatedTicket , int id, ClaimsPrincipal user)
        {

            var ticket = GetById(id,user);

            ticket.Title = updatedTicket.Title;
            ticket.Type = GetType(updatedTicket);
            ticket.TickeTypeId = updatedTicket.TickeTypeId;
            ticket.Priority = GetPriority(updatedTicket);
            ticket.PriorityId = updatedTicket.PriorityId;
            ticket.State = GetState(updatedTicket);
            ticket.StateId = updatedTicket.StateId;
            ticket.Description = updatedTicket.Description;
            ticket.UpdatedOn = DateTime.Now;
            ticket.UpdatedBy = user.Identity.Name;
            DbContext.Update(ticket);
            Commit();
        }
        public Priority GetPriority(Ticket ticket)
        {
            return DbContext
                   .Priority
                   .FirstOrDefault(e => e.Id == ticket.PriorityId);
        }
        public TicketType GetType(Ticket ticket)
        {
            return DbContext
                   .TicketTypes
                   .FirstOrDefault(e => e.Id == ticket.TickeTypeId);
        }
        public TicketState GetState(Ticket ticket)
        {
            return DbContext
                   .TicketStates
                   .FirstOrDefault(e => e.Id == ticket.StateId);
        }
       
        public List<Attachment> GetTicketAttachments(Ticket ticket)
        {
            List<int> ids = new List<int>();
            ids =DbContext.TicketAttachments.Where(e=>e.TicketId == ticket.Id).Select(e=>e.AttachmentId).ToList();
            List<Attachment> ticketAttachments = new List<Attachment>();
            foreach(int id in ids)
            {
                ticketAttachments.Add(DbContext.Attachment.FirstOrDefault(e => e.Id == id));
            }

            return ticketAttachments;
        }
        public Project GetTicketProject(Ticket ticket)
        {

            return DbContext.Projects.FirstOrDefault(e => e.Id == ticket.ProjectId);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Ticket GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
