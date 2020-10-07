using Escuela.Api.Models.Enums;

namespace Escuela.Api.Models
{
    public class Student : Person
    {
        public string MajorName { get; set; }
        public Major MajorId { get; set; }
    }
}
