using DevFreela.Application.InputModels;
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
    public class ProjectService 
    {
        private readonly DevFreelaDbContext _dbContext;
        public ProjectService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;       
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


    }
}
