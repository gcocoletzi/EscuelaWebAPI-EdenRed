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
            
            apiEnrollment.Professor = string.Concat(dataEnrollment.Course.Professor.Person.FirstName,
                                                    dataEnrollment.Course.Professor.Person.LastName);
            apiEnrollment.ProfessionalLicense = dataEnrollment.Course.Professor.ProfessionalLicense;

            apiEnrollment.Student = string.Concat(dataEnrollment.Student.Person.FirstName,
                                                    dataEnrollment.Student.Person.LastName);
            apiEnrollment.Major = ((Major)dataEnrollment.Student.MajorId).GetDisplayName();
            apiEnrollment.Grade = dataEnrollment.Grade;

            apiEnrollment.Class = dataEnrollment.Course.Class.ClassName;
            apiEnrollment.Schedule = dataEnrollment.Course.Schedule;
            apiEnrollment.Period = dataEnrollment.Period;

            return apiEnrollment;
        }
    }
}
