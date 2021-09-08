using System;
using System.Collections.Generic;
using Tickets.Domain.Lookups.Entities;
using Tickets.Domain.Projects.Entities;
using Tickets.Infrastrucure.Data;

namespace Tickets.Application.Services
{
    public class ProjectAppService 
    {
        private TicketsDbContext DbContext;

        public ProjectAppService(TicketsDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public void Insert(Project project)
        {
            // project.CreatedBy = 
            project.CreatedOn = DateTime.Now;
            //  var projectStatus = DbContext.ProjectStatus.FirstOrDefault(s => s.Status == project.ProjectType);
            //  project.TypeId = projectStatus.Id;
            project.Tickets = null;
            DbContext.projects.Add(project);
          
        }
        public bool Commit()
        {
            if (DbContext.SaveChanges() > 0)
                return true;
            else
                return false;
        }
        public void Delete(int id)
        {

            throw new NotImplementedException();
        }
        public void Delete(Project project)
        {

        }
        public Project GetById(int id)
        {

            throw new NotImplementedException();
        }
        
        public List<Project> GetAll()
        {

            throw new NotImplementedException();
        }
        public void Update(Project project)
        {

            throw new NotImplementedException();
        }
        public void Update(int id)
        {

            throw new NotImplementedException();
        }
    }
}
