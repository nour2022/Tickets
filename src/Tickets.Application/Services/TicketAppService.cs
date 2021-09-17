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

        public bool Delete(int id)
        {
            var ticket = GetById(id);
            return Delete(ticket);
        }

        public bool Delete(Ticket entity)
        {
           //var projectTicket= DbContext.Projects.FirstOrDefault(t => t.Tickets.FirstOrDefault(s => s.Id == entity.Id) != null);
           // if(projectTicket != null)
           // {
           //     DbContext.Projects.FirstOrDefault(s => s.Tickets.Remove(entity));
           // }
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
            //var currentUser = DbContext.Users.Find(ClaimTypes.Name);
           // entity.CreatedBy = " ";
            entity.CreatedOn = DateTime.Now;

            DbContext.Tickets.Add(entity);
        }

        public void Update(int id)
        {
            var ticket = GetById(id);
            Update(ticket,id);
        }

        public void Update(Ticket updatedTicket , int id)
        {

            var ticket = GetById(id);

            ticket.Title = updatedTicket.Title;
            ticket.Type = GetType(updatedTicket);
            ticket.TickeTypeId = updatedTicket.TickeTypeId;
            ticket.Priority = GetPriority(updatedTicket);
            ticket.PriorityId = updatedTicket.PriorityId;
            ticket.State = GetState(updatedTicket);
            ticket.StateId = updatedTicket.StateId;
            ticket.Description = updatedTicket.Description;
            ticket.UpdatedOn = DateTime.Now;
            ticket.UpdatedBy = " /0";
            DbContext.Update(ticket);
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
        public List<Project> SelectAllProjects()
        {

            return DbContext.Projects.ToList();
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
    }
}
