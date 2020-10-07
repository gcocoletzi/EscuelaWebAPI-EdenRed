using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Model.Configuration
{
    public class ClassEntityConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("class", "dbo");
            builder.HasKey(e => e.Id).HasName("PK__class__3213E83F4C03CEAC");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.ClassName).HasColumnName("class_name");            
        }
    }
}
