﻿using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Model
{
    public class Enrollment
    {
        private Course _course;
        private Student _student;
        private ILazyLoader LazyLoad { get; set; }

        public Enrollment(ILazyLoader lazyLoader)
        {
            LazyLoad = lazyLoader;
        }

        public Enrollment()
        {
            //Course = new Course();
            //Student = new Student();
        }

        public long Id { get; set; }
        public long CourseId { get; set; }
        public long StudentId { get; set; }
        public int EnrollmentStatus { get; set; }
        public DateTime LastStatusChangeDate { get; set; }

        public Course Course
        {
            get => LazyLoad.Load(this, ref _course);
            set => _course = value;
        }

        public Student Student
        {
            get => LazyLoad.Load(this, ref _student);
            set => _student = value;
        }
    }
}
