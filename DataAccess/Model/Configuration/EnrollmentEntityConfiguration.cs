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
            builder.HasKey(e => e.Id).HasName("PK__enrollme__3213E83FF9B3258C");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.CourseId).HasColumnName("course_id");
            builder.Property(e => e.StudentId).HasColumnName("student_id");
            builder.Property(e => e.EnrollmentStatus).HasColumnName("enrollment_status");
            builder.Property(e => e.LastStatusChangeDate).HasColumnName("last_changed_status_date");
            builder.HasOne(e => e.Course).WithMany().HasForeignKey(e => e.CourseId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Student).WithMany().HasForeignKey(e => e.StudentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
