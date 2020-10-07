using DataAccess.Model;
using DataAccess.Model.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class SchoolDbContext : DbContext
    {
        private string ConnectionString;

        public SchoolDbContext(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {
        }


        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Entities
            modelBuilder.ApplyConfiguration(new AddressEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ClassEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CourseEntityConfiguration());
            modelBuilder.ApplyConfiguration(new EnrollmentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MajorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PersonEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new StudentEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public async Task InsertNewStudent(Student student, CancellationToken token)
        {
            Students.Add(student);
            await SaveChangesAsync(token);
        }

        public async Task InsertNewProfessor(Professor professor, CancellationToken token)
        {
            Professors.Add(professor);
            await SaveChangesAsync(token);
        }

        public async Task<List<Enrollment>> GetEnrollments(CancellationToken cancellationToken)
        {
            return await RetrieveEnrollment(this, cancellationToken);
        }

        public async Task<List<Professor>> GetProfessors(CancellationToken cancellationToken)
        {
            return await RetrieveProfessors(this, cancellationToken);
        }

        public async Task<List<Student>> GetStudents(CancellationToken cancellationToken)
        {
            return await RetrieveStudents(this, cancellationToken);
        }

        private static Func<SchoolDbContext, CancellationToken, Task<List<Student>>> RetrieveStudents =
            async (SchoolDbContext context, CancellationToken cancellationToken) =>
            {
                return await (from s in context.Students
                              select s).ToListAsync(cancellationToken);
            };

        private static Func<SchoolDbContext, CancellationToken, Task<List<Professor>>> RetrieveProfessors =
            async (SchoolDbContext context, CancellationToken cancellationToken) =>
            {
                return await (from p in context.Professors
                              select p).ToListAsync(cancellationToken);
            };

        private static Func<SchoolDbContext, CancellationToken, Task<List<Enrollment>>> RetrieveEnrollment =
            async (SchoolDbContext context, CancellationToken cancellationToken) =>
            {
                return await (from r in context.Enrollments
                              select r).ToListAsync(cancellationToken);
            };

    }
}
