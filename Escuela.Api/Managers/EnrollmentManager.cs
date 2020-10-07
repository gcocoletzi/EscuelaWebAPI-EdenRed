using DataAccess.Context;
using Escuela.Api.Converters;
using Escuela.Api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Escuela.Api.Managers
{
    public class EnrollmentManager
    {
        private SchoolDbContext _context;

        public EnrollmentManager(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task<List<Enrollment>> GetAllEnrollments(CancellationToken cancellationToken)
        {
            var dataEnrollments = await _context.GetEnrollments(cancellationToken);
            var apiEnrollments = new List<Enrollment>();
            foreach (var enrollment in dataEnrollments)
            {
                var apiEnrollment = EnrollmentConverter.EntityToApiModel(enrollment);
                apiEnrollments.Add(apiEnrollment);
            }

            return apiEnrollments;
        }
            

    }
}
