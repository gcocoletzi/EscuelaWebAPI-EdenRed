using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace DataAccess.Model
{
    public class Address
    {
        public long Id { get; set; }
        public string StreetAndNumber { get; set; }        
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}