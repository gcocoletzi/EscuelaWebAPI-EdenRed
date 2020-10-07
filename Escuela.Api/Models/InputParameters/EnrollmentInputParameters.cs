using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Api.Models.InputParameters
{
    public class EnrollmentInputParameters
    {
        public long? StudentId { get; set; }
        public string Period { get; set; }
    }
}
