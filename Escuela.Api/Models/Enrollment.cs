using Escuela.Api.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Api.Models
{
    public class Enrollment
    {
        public long Id { get; set; }
        [JsonRequired]
        public long StudentId { get; set; }
        public string Student { get; set; }
        public string Major { get; set; }
        public string Professor { get; set; }
        [JsonRequired]
        public long CourseId { get; set; }
        public string ProfessionalLicense { get; set; }
        public string Class { get; set; }
        public string Period { get; set; }
        public string Schedule { get; set; }
        public string CourseStatus { get; set; }
        public EnrollmentStatus EnrollmentStatusId { get; set; }
        public string EnrollmentStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime LastStatusChangeDate { get; set; }
    }
}
