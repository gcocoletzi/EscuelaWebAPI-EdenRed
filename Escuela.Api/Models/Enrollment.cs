using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Api.Models
{
    public class Enrollment
    {
        public string Student { get; set; }
        public string Major { get; set; }
        public string Professor { get; set; }
        public string ProfessionalLicense { get; set; }
        public string Class { get; set; }
        public double? Grade { get; set; }
        public string SchoolCycle { get; set; }
        public string Schedule { get; set; }

    }
}
