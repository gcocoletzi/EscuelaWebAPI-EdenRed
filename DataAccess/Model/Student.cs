using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace DataAccess.Model
{
    public class Student
    {
        private Major _major;
        private Person _person;
        private ILazyLoader LazyLoader { get; set; }

        public Student()
        {
        }
        public Student(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        public long Id { get; set; }
        public long PersonId { get; set; }
        public long MajorId { get; set; }

        public Person Person
        {
            get => LazyLoader.Load(this, ref _person);
            set => _person = value;
        }
        public Major Major
        {
            get => LazyLoader.Load(this, ref _major);
            set => _major = value;
        }
    }
}
