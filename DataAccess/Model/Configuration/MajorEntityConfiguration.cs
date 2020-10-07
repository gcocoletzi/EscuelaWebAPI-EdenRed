using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Model.Configuration
{
    public class MajorEntityConfiguration : IEntityTypeConfiguration<Major>
    {
        public void Configure(EntityTypeBuilder<Major> builder)
        {
            builder.ToTable("major", "dbo");
            builder.HasKey(e => e.Id).HasName("PK__major__3213E83F7FFDD032");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.MajorName).HasColumnName("major_name");
        }
    }
}
