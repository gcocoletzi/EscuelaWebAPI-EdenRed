using Escuela.Api.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Escuela.Api.Managers
{
    public interface IProfessorManager
    {
        Task<List<Professor>> GetAllProfessors(CancellationToken token);
        Task InsertProfessor(Professor professor, CancellationToken token);
    }
}