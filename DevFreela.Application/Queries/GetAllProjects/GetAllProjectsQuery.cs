using DevFreela.Application.ViewsModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<List<ProjectViewModels>>
    {
        public GetAllProjectsQuery(string query)
        {
            this.query = query;
        }

        public string query { get; set; }
    }
}
