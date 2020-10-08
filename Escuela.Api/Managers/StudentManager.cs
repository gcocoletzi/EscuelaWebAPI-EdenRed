using DataAccess.Context;
using Escuela.Api.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApiModel = Escuela.Api.Models;

namespace Escuela.Api.Managers
{
    public class StudentManager : IStudentManager
    {
        private SchoolDbContext _dbContext;
        public StudentManager(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InsertStudent(ApiModel.Student student, CancellationToken cancellationToken)
        {
            var dataStudent = StudentConverter.ApiToEntityModel(student);
            await _dbContext.InsertNewStudent(dataStudent, cancellationToken);
            return;
        }


        public async Task<List<ApiModel.Student>> GetAllStudents(CancellationToken token)
        {
            var students = new List<ApiModel.Student>();
            var dataStudents = await _dbContext.GetStudents(token);

            foreach (var student in dataStudents)
            {
                var apiStudent = StudentConverter.EntityToApiModel(student);
                students.Add(apiStudent);
            }

            return students;
        }
    }
}
