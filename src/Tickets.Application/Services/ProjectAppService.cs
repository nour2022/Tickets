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
        public void Insert(ProjectDto project)
        {
            Project = new Project
            {
                Title = project.Title,
                ClientName=project.ClientName,
                CreatedOn = DateTime.Now,
                CreatedBy = " ",
                ProjectType = GetProjectStatus(project.ProjectType.Id),
                TypeId = project.ProjectType.Id,
                Tickets = null

            };
            DbContext.Projects.Add(Project);
        }
        public void Insert(Project project)
        {
         //  // var currentUser = DbContext.Users.Find(ClaimTypes.Name);
         ////   project.CreatedBy = currentUser.FullName;
            project.CreatedOn = DateTime.Now;
            project.CreatedBy = " ";
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
        public void Delete(ProjectDto project)
        {
            Project = new Project();
            Project = GetById(project.Id);
            Delete(Project);
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
        public ProjectDto Find(int id)
        {
            
            Project = new Project();
            Project = GetById(id);
           
            return Mapper(Project);
        }
        public Project GetById(int id)
        {

            return DbContext.Projects.FirstOrDefault(p => p.Id == id);
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
        public void Update(ProjectDto updatedProject,int id)
        {
            var project = new Project();
            project = GetById(id);
        
            project.ClientName = updatedProject.ClientName;
            project.Title = updatedProject.Title;
            project.ProjectType = GetProjectStatus(updatedProject.ProjectType.Id);
            project.TypeId = updatedProject.ProjectType.Id;
            project.UpdatedOn = DateTime.Now;
            project.UpdatedBy = " /0";
            DbContext.Update(project);
        }
        public void Update(int id)
        {

           var project = Find(id);
            Update(project,id);
        }

        List<Project> IAppService<Project>.GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Project entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
