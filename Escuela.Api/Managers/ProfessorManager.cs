using DataAccess.Context;
using Escuela.Api.Converters;
using Escuela.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ApiModel = Escuela.Api.Models;

namespace Escuela.Api.Managers
{
    public class ProfessorManager
    {
        private SchoolDbContext _dbContext;

        public ProfessorManager(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Professor>> GetAllProfessors(CancellationToken token)
        {
            var professors = new List<ApiModel.Professor>();
            var dataProfessors = await _dbContext.GetProfessors(token);

            foreach (var professor in dataProfessors)
            {
                var apiProfessor = ProfessorConverter.EntityToApiModel(professor);
                professors.Add(apiProfessor);
            }

            return professors;
        }

        public async Task InsertProfessor(Professor professor, CancellationToken token)
        {
            var dataStudent = ProfessorConverter.ApiToEntityModel(professor);
            await _dbContext.InsertNewProfessor(dataStudent, token);
            return;
        }
    }
}