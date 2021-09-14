//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Tickets.Domain.Entities;
//using Tickets.Infrastrucure.Data;

//namespace Tickets.Application.Services
//{
//   public  class AttachmentAppService : IAppService<Attachment>
//    {
//        private TicketsDbContext DbContext;

//        public AttachmentAppService(TicketsDbContext dbContext)
//        {
//            DbContext = dbContext;
//        }
//        public bool Commit()
//        {
//            DbContext.SaveChanges();
//            return true;
//        }

//        public bool Delete(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public bool Delete(Attachment entity)
//        {
//            throw new NotImplementedException();
//        }

//        public List<Attachment> GetAll()
//        {
//            throw new NotImplementedException();
//        }

//        public Attachment GetById(int id)
//        {
//            return DbContext.Attachment.FirstOrDefault(e => e.Id == id);
//        }

//        public void Insert(Attachment entity)
//        {
//            DbContext.Attachment.Add(entity);
           
//        }

//        public void Update(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public void Update(Attachment entity, int id)
//        {
//            throw new NotImplementedException();
//        }
//    }

//}
