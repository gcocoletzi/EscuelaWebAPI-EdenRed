using DataAccess.Context;
using Escuela.Api.Converters;
using Escuela.Api.Models;
using Escuela.Api.Models.Enums;
using Escuela.Api.Models.InputParameters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using DataModel = DataAccess.Model;

namespace Escuela.Api.Managers
{
    public class EnrollmentManager
    {
        private SchoolDbContext _context;

        public EnrollmentManager(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task EnrollToCourse(Enrollment enrollment, CancellationToken token)
        {
            var dataEnrollment = EnrollmentConverter.ApiToEntityModel(enrollment);
            dataEnrollment.EnrollmentStatus = (int)EnrollmentStatus.Enrolled;
            dataEnrollment.LastStatusChangeDate = DateTime.Now;

            await _context.InsertNewEnrollment(dataEnrollment, token);

            return;
        }

        public async Task<Enrollment> GetSingleEnrollment(long enrollmentId, CancellationToken cancellationToken)
        {
            var enrollment = await _context.GetEnrollmentById(enrollmentId, cancellationToken);
            var apiEnrollment = EnrollmentConverter.EntityToApiModel(enrollment);

            return apiEnrollment;

        }

        public async Task<Enrollment> UpdateEnrollment(Enrollment enrollment, EnrollmentInputParameters inputParameters,
                                                        long enrollmentId, CancellationToken cancellationToken)
        {
            var dataEnrollment = await _context.GetEnrollmentById(enrollmentId, cancellationToken);
            if (dataEnrollment.StudentId != inputParameters.StudentId)
            {
                throw new ArgumentException("Student Ids don't match.");
            }
            dataEnrollment.EnrollmentStatus = (int)enrollment.EnrollmentStatusId;

            var updatedEnrollment = await _context.UpdateEnrollmentStatus(dataEnrollment, cancellationToken);
            var updatedApiEnrollment = EnrollmentConverter.EntityToApiModel(updatedEnrollment);

            return updatedApiEnrollment;
        }

        public async Task<List<Enrollment>> GetEnrollments(EnrollmentInputParameters inputParameters, CancellationToken cancellationToken)
        {
            var apiEnrollments = new List<Enrollment>();
            var dataEnrollments = new List<DataModel.Enrollment>();
            if (!inputParameters.StudentId.HasValue && string.IsNullOrWhiteSpace(inputParameters.Period))
            {
                dataEnrollments = await _context.GetEnrollments(cancellationToken);
            }
            else if (inputParameters.StudentId.HasValue && string.IsNullOrWhiteSpace(inputParameters.Period))
            {
                dataEnrollments = await _context.GetEnrollmentsByStudentId(inputParameters.StudentId.Value, cancellationToken);
            }
            else if (inputParameters.StudentId.HasValue && !string.IsNullOrWhiteSpace(inputParameters.Period))
            {
                dataEnrollments = await _context.GetEnrollmentsByStudentAndPeriod(inputParameters.StudentId.Value, inputParameters.Period, cancellationToken);
            }
            else
            {
                dataEnrollments = await _context.GetEnrollmentsByPeriod(inputParameters.Period, cancellationToken);
            }
           

            apiEnrollments = ArrangeAsList(dataEnrollments);
            return apiEnrollments;
        }

        private List<Enrollment> ArrangeAsList(List<DataModel.Enrollment> dataEnrollments)
        {
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
