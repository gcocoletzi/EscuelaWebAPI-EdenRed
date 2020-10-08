using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Model.Configuration
{
    public class CourseEntityConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("course", "dbo");
            builder.HasKey(e => e.Id).HasName("PK__course__3213E83F190164D6");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Schedule).HasColumnName("schedule");
            builder.Property(e => e.ProfessorId).HasColumnName("professor_id");
            builder.Property(e => e.ClassId).HasColumnName("class_id");
            builder.Property(e => e.Period).HasColumnName("period");
            builder.Property(e => e.StartDate).HasColumnName("start_date");
            builder.Property(e => e.CourseStatus).HasColumnName("course_status");
            builder.HasOne(e => e.Class).WithMany().HasForeignKey(e => e.ClassId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Professor).WithMany().HasForeignKey(e => e.ProfessorId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
