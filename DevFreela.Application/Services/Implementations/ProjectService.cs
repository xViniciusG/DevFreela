﻿using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewsModels;
using DevFreela.Core.Entities;
using DevFreela.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;
        public ProjectService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;       
        } 
        public int Create(NewProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdClient,inputModel.IdFreelancer,inputModel.TotalCost);
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();

            return project.Id;
        }

        public void CreateComment(CreateCommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);
            _dbContext.ProjectComments.Add(comment);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            project.Cancel();
            _dbContext.SaveChanges();
        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            project.Finish();
            _dbContext.SaveChanges();
        }

        public List<ProjectViewModels> GetAll(string query)
        {
            var projects = _dbContext.Projects;

            var ProjectViewModels = projects
                .Select(p => new ProjectViewModels(p.Id, p.Title, p.CreatedAt))
                .ToList();
            return ProjectViewModels;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefault(p => p.Id == id);


            if (project == null)
            {
               return null;
            } 

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                   project.Id,
                   project.Title,
                   project.Description,
                   project.TotalCost,
                   project.StartedAt,
                   project.FinishedAt,
                   project.Client.FullName,
                   project.Freelancer.FullName

                   );
            return projectDetailsViewModel;
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);
            project.Start();
            _dbContext.SaveChanges();
        }

        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);
            project.Update(inputModel.Title,inputModel.Description,inputModel.TotalCost);
            _dbContext.SaveChanges();
        }
    }
}
