using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DataAccess.Model
{
    public class Professor
    {
        private Person _person;        
        private ILazyLoader LazyLoader { get; set; }

        public Professor(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        public Professor()
        {
        }

        public long Id { get; set; }
        public long PersonId { get; set; }
        public string ProfessionalLicense { get; set; }
                
        public Person Person
        {
            get => LazyLoader.Load(this, ref _person);
            set => _person = value;
        }
    }
}
