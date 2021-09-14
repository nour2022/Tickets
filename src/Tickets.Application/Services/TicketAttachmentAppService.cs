using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Domain.Tickets.Entities;
using Tickets.Infrastrucure.Data;

namespace Tickets.Application.Services
{
   public class TicketAttachmentAppService:IAppService<TicketAttachment>
    {
        private TicketsDbContext DbContext;

        public TicketAttachmentAppService(TicketsDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public bool Commit()
        {
            DbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TicketAttachment entity)
        {
            throw new NotImplementedException();
        }

        public List<TicketAttachment> GetAll()
        {
            throw new NotImplementedException();
        }

        public TicketAttachment GetById(int id)
        {
            return DbContext.TicketAttachments.FirstOrDefault(e => e.TicketId == id);
        }

        public void Insert(TicketAttachment entity)
        {
            DbContext.TicketAttachments.Add(entity);
            Commit();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TicketAttachment entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
