using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infraestructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        public SkillRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SkillDTO>> GetAllAsync()
        {
            var skills = _dbContext.Skills;
            var skillsViewModel = await skills
                .Select(s => new SkillDTO(s.Id, s.Description))
                .ToListAsync();
            return skillsViewModel;

            // Maneira usando Dapper 
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
