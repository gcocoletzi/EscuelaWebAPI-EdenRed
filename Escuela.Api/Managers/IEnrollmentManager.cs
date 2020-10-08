using Escuela.Api.Models;
using Escuela.Api.Models.InputParameters;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Escuela.Api.Managers
{
    public interface IEnrollmentManager
    {
        Task EnrollToCourse(Enrollment enrollment, CancellationToken token);
        Task<List<Enrollment>> GetEnrollments(EnrollmentInputParameters inputParameters, CancellationToken cancellationToken);
        Task<Enrollment> GetSingleEnrollment(long enrollmentId, CancellationToken cancellationToken);
        Task<Enrollment> UpdateEnrollment(Enrollment enrollment, EnrollmentInputParameters inputParameters, long enrollmentId, CancellationToken cancellationToken);
    }
}