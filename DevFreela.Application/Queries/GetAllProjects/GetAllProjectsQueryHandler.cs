using DevFreela.Application.ViewsModels;
using DevFreela.Core.Repositories;
using DevFreela.Infraestructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllProjects
{
    internal class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModels>>
    {
        private readonly IProjectRepository _projectRepository;
        public GetAllProjectsQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository; 
        }
        public async Task<List<ProjectViewModels>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetAllAsync();

            var ProjectViewModels = projects
                .Select(p => new ProjectViewModels(p.Id, p.Title, p.CreatedAt))
                .ToList();
            return ProjectViewModels;

        }
    }
}
