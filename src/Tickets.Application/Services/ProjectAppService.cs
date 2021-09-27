using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tickets.Application.DTOs;
using Tickets.Domain.Entities.UserEntity;
using Tickets.Domain.Lookups.Entities;
using Tickets.Domain.Projects.Entities;
using Tickets.Infrastrucure.Data;

namespace Tickets.Application.Services
{
    public class ProjectAppService : IAppService<Project>
    {
        private TicketsDbContext DbContext;
        private Project Project;

        public ProjectAppService(TicketsDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public void Insert(ProjectDto project, ClaimsPrincipal user)
        {
            Project = new Project
            {
                Title = project.Title,
                ClientName=project.ClientName,
                CreatedOn = DateTime.Now,
                CreatedBy = user.Identity.Name,
                ProjectType = GetProjectStatus(project.ProjectType.Id),
                TypeId = project.ProjectType.Id,
                Tickets = null

            };
            DbContext.Projects.Add(Project);
            Commit();
        }
        //public void Insert(Project project)
        //{
       
        // ////   project.CreatedBy = currentUser.FullName;
        //    project.CreatedOn = DateTime.Now;
        //    project.CreatedBy = " ";
        //    project.ProjectType = GetProjectStatus(project.TypeId);
        //    project.Tickets = null;

        //    DbContext.Projects.Add(project);

        //}
       
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
        public bool Delete(int id, ClaimsPrincipal user)
        {

            var project = GetById(id, user);
            if (project == null) return false;
            return Delete(project);
        }
        public bool Delete(ProjectDto project, ClaimsPrincipal user)
        {
            Project = new Project();
            Project = GetById(project.Id, user);
           
           if(Delete(Project))
            {
                return true;
            }
            
                return false;
            
        }
        public bool Delete(Project project)
        {
            if (project == null)
            {
                return false;
            }
            if (HasTickets(project))
                return false;
            else
            {
                DbContext.Projects.Remove(project);
                Commit();
            }
            return true;
        }
        private bool HasTickets(Project project)
        {
            var ticketsCount = DbContext.Tickets.Where(e=>e.ProjectId == project.Id).Count();
            if(ticketsCount > 0)
            {
                return true;
            }else
            {
                return false;
            }
           
        }
        public ProjectDto Find(int id, ClaimsPrincipal user)
        {
            
            Project = new Project();
            Project = GetById(id,user);
           
            return Mapper(Project);
        }
        public Project GetById(int id, ClaimsPrincipal user)
        {
            var project = DbContext.Projects.FirstOrDefault(p => p.Id == id);
            if (IsAuthenticatedUser(user, project))
            {
                return project;
            }
            return null;
            
        }

        public List<ProjectDto> GetAll()
        {
            var projects = DbContext.Projects.ToList();
            List<ProjectDto> projectDtos = new List<ProjectDto>();
            foreach(var project in projects)
            {
                var dto = new ProjectDto();
                dto = Mapper(project);
                projectDtos.Add(dto);
            }
            return projectDtos;
        }
        public List<ProjectDto> GetAll(ClaimsPrincipal user)
        {
            if (user.IsInRole("User"))
            {
                var projects = DbContext.Projects.Where(e=>e.ClientName==user.Identity.Name || e.CreatedBy==user.Identity.Name).ToList();
                List<ProjectDto> projectDtos = new List<ProjectDto>();
                foreach (var project in projects)
                {
                    var dto = new ProjectDto();
                    dto = Mapper(project);
                    projectDtos.Add(dto);
                }
                return projectDtos;
            }
            else
            {
                return GetAll();
            }
          
        }
        public ProjectDto Mapper(Project Project)
        {
            var projectDto = new ProjectDto()
            {
                Id = Project.Id,
                Title = Project.Title,
                ProjectType = new ProjectStatusDto()
                {
                    Id = Project.TypeId,
                    Type = GetProjectStatus(Project.TypeId).Status
                },
                ClientName = Project.ClientName
            };
            return projectDto;
        }
        public void Update(ProjectDto updatedProject,int id, ClaimsPrincipal user)
        {
            var project = new Project();
            project = GetById(id,user);
        
            project.ClientName = updatedProject.ClientName;
            project.Title = updatedProject.Title;
            project.ProjectType = GetProjectStatus(updatedProject.ProjectType.Id);
            project.TypeId = updatedProject.ProjectType.Id;
            project.UpdatedOn = DateTime.Now;
            project.UpdatedBy = " /0";
            DbContext.Update(project);
            Commit();
        }
        public void Update(int id,ClaimsPrincipal user)
        {

           var project = Find(id,user);
            Update(project,id,user);
        }
        public bool IsAuthenticatedUser(ClaimsPrincipal user,Project project)
        {
            bool IsAuthenticated = user.IsInRole("Admin")
                              || user.IsInRole("Manager")
                              || user.IsInRole("Developer Team");
            if ((user.IsInRole("User") 
            && (project.CreatedBy == user.Identity.Name)
            || (project.ClientName==user.Identity.Name))
            ||IsAuthenticated) 
            {
                return true;
            }
            return false;
        }

        List<Project> IAppService<Project>.GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Project entity, int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Project entity, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Project GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
