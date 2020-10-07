using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Api.Models
{
    public class Person
    {
        public Person()
        {
            Address = new Address();
        }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
    }
}
