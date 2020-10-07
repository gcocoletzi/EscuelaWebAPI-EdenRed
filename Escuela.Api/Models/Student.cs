using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Api.Models
{
    public class Student : Person
    {
        public string MajorName { get; set; }
        public Major MajorId { get; set; }
    }
}
