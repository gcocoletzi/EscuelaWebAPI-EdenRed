using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Model.Configuration
{
    public class StudentEntityConfiguration :IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("student", "dbo");
            builder.HasKey(e => e.Id).HasName("PK__student__3213E83F034D2747");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.MajorId).HasColumnName("major_id");
            builder.Property(e => e.PersonId).HasColumnName("person_id");
            builder.HasOne(e => e.Person).WithMany().HasForeignKey(e => e.PersonId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Major).WithMany().HasForeignKey(e => e.MajorId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
