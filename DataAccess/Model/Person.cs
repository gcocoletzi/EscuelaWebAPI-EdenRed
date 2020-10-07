using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Model
{
    public class Person
    {
        private Address _address;
        private ILazyLoader _lazyLoader;

        public Person()
        {
        }
        public Person(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }        
        public long AddressId { get; set; }

        public Address Address
        {
            get => _lazyLoader.Load(this, ref _address);
            set => _address = value;
        }
    }
}
