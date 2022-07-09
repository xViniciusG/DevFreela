using DevFreela.Application.ViewsModels;
using DevFreela.Infraestructure.Persistence;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;
        public GetAllSkillsQueryHandler(DevFreelaDbContext dbContext,IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }
        public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {

            var skills = _dbContext.Skills;

            var skillsViewModel = await skills

                .Select(s => new SkillViewModel(s.Id, s.Description))
                .ToListAsync();

            return skillsViewModel;


            //using (var sqlConnection = new SqlConnection(_connectionString))
            //{ 
            //    sqlConnection.Open();

            //    var script = "Select Id, Description From Skills";

            //    var skills = await sqlConnection.QueryAsync<SkillViewModel>(script);

            //    return skills.ToList();
            //}


        }
    }
}
