using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tickets.Domain.Entities.UserEntity;
using Tickets.Domain.Lookups.Entities;
using Tickets.Domain.Projects.Entities;
using Tickets.Infrastrucure.Data;

namespace Tickets.Application.Services
{
    public class ProjectAppService : IAppService<Project>
    {
        private TicketsDbContext DbContext;

        public ProjectAppService(TicketsDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public void Insert(Project project)
        {
         //  // var currentUser = DbContext.Users.Find(ClaimTypes.Name);
         ////   project.CreatedBy = currentUser.FullName;
            project.CreatedOn = DateTime.Now;

            project.ProjectType = GetProjectStatus(project.TypeId);
            project.Tickets = null;

            DbContext.Projects.Add(project);

        }
        public ProjectStatus GetProjectStatus(int id)
        {

            var status = DbContext.projectStatus.Find(id);
            return status;
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

            var project = GetById(id);
            return Delete(project);
        }
        public bool Delete(Project project)
        {
            if (project.Tickets != null)
                return false;
            else
            {
                DbContext.Projects.Remove(project);

            }
            return true;
        }
        public Project GetById(int id)
        {

            return DbContext.Projects.FirstOrDefault(p => p.Id == id);
        }

        public List<Project> GetAll()
        {
            return DbContext.Projects.ToList();
        }
        public void Update(Project updatedProject,int id)
        {
            var project = new Project();
            project = GetById(id);
        
            project.ClientName = updatedProject.ClientName;
            project.Title = updatedProject.Title;
            project.ProjectType = GetProjectStatus(updatedProject.TypeId);
            project.TypeId = updatedProject.TypeId;
            project.UpdatedOn = DateTime.Now;
            project.UpdatedBy = " /0";
            DbContext.Update(project);
        }
        public void Update(int id)
        {

           var project = GetById(id);
            Update(project,id);
        }
    }
}
