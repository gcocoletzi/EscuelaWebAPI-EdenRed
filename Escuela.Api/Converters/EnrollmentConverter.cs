using Microsoft.AspNetCore.Components.Forms;
using Microsoft.OpenApi.Extensions;
using Escuela.Api.Models.Enums;
using ApiModel = Escuela.Api.Models;
using DataModel = DataAccess.Model;

namespace Escuela.Api.Converters
{
    public class EnrollmentConverter
    {
        public static ApiModel.Enrollment EntityToApiModel(DataModel.Enrollment dataEnrollment)
        {
            var apiEnrollment = new ApiModel.Enrollment();

            apiEnrollment.Id = dataEnrollment.Id;

            apiEnrollment.Professor = string.Concat(dataEnrollment.Course.Professor.Person.FirstName,
                                               " ", dataEnrollment.Course.Professor.Person.LastName);
            apiEnrollment.ProfessionalLicense = dataEnrollment.Course.Professor.ProfessionalLicense;

            apiEnrollment.CourseId = dataEnrollment.CourseId;
            apiEnrollment.StudentId = dataEnrollment.StudentId;
            apiEnrollment.Student = string.Concat(dataEnrollment.Student.Person.FirstName,
                                               " ", dataEnrollment.Student.Person.LastName);
            apiEnrollment.Major = ((Major)dataEnrollment.Student.MajorId).GetDisplayName();

            apiEnrollment.CourseStatus = ((CourseStatus)dataEnrollment.Course.CourseStatus).GetDisplayName(); ;
            apiEnrollment.EnrollmentStatus = ((EnrollmentStatus)dataEnrollment.EnrollmentStatus).GetDisplayName();
            apiEnrollment.EnrollmentStatusId = (EnrollmentStatus)dataEnrollment.EnrollmentStatus;

            apiEnrollment.StartDate = dataEnrollment.Course.StartDate;
            apiEnrollment.LastStatusChangeDate = dataEnrollment.LastStatusChangeDate;

            apiEnrollment.Class = dataEnrollment.Course.Class.ClassName;
            apiEnrollment.Schedule = dataEnrollment.Course.Schedule;
            apiEnrollment.Period = dataEnrollment.Course.Period;

            return apiEnrollment;
        }

        public static DataModel.Enrollment ApiToEntityModel(ApiModel.Enrollment apiEnrollment)
        {
            var dataEnrollment = new DataModel.Enrollment();

            dataEnrollment.StudentId = apiEnrollment.StudentId;
            dataEnrollment.CourseId = apiEnrollment.CourseId;

            return dataEnrollment;
        }
    }
}
