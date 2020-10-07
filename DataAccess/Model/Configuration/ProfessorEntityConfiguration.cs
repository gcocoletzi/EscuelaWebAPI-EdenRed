using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Model.Configuration
{
    public class ProfessorEntityConfiguration : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("professor", "dbo");
            builder.HasKey(e => e.Id).HasName("PK__professo__3213E83F5C507270");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.ProfessionalLicense).HasColumnName("professional_license");
            builder.Property(e => e.PersonId).HasColumnName("person_id");
            builder.HasOne(e => e.Person).WithMany().HasForeignKey(e => e.PersonId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
