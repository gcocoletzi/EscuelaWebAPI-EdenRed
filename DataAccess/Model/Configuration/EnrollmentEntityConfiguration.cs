using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Model.Configuration
{
    public class EnrollmentEntityConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("enrollment", "dbo");
            builder.HasKey(e => e.Id).HasName("PK__enrollme__3213E83F7E104383");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.CourseId).HasColumnName("course_id");
            builder.Property(e => e.Period).HasColumnName("period");
            builder.Property(e => e.Grade).HasColumnName("grade");
            builder.Property(e => e.StudentId).HasColumnName("student_id");
            builder.HasOne(e => e.Course).WithMany().HasForeignKey(e => e.CourseId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Student).WithMany().HasForeignKey(e => e.StudentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
