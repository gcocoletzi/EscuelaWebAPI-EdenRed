using Escuela.Api.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Escuela.Api.Managers
{
    public interface IStudentManager
    {
        Task<List<Student>> GetAllStudents(CancellationToken token);
        Task InsertStudent(Student student, CancellationToken cancellationToken);
    }
}