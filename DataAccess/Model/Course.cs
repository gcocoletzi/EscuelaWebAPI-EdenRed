using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Model
{
    public class Course
    {
        private Class _class;
        private Professor _professor;
        private ILazyLoader _lazyLoader;
        
        public Course(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        public long Id { get; set; }
        public long ClassId { get; set; }
        public long ProfessorId { get; set; }
        public string Schedule { get; set; }

        public Class Class
        {
            get => _lazyLoader.Load(this, ref _class);
            set => _class = value;
        }

        public Professor Professor
        {
            get => _lazyLoader.Load(this, ref _professor);
            set => _professor = value;
        }
    }
}
