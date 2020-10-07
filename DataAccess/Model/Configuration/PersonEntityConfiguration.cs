using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Model.Configuration
{
    public class PersonEntityConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("person", "dbo");
            builder.HasKey(e => e.Id).HasName("PK__person__3213E83F5FFE1071");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.FirstName).HasColumnName("first_name");
            builder.Property(e => e.LastName).HasColumnName("last_name");
            builder.Property(e => e.MiddleName).HasColumnName("middle_name");
            builder.Property(e => e.Birthday).HasColumnName("birthday");
            builder.Property(e => e.Phone).HasColumnName("phone");
            builder.Property(e => e.AddressId).HasColumnName("address_id");
            builder.HasOne(e => e.Address).WithMany().HasForeignKey(e => e.AddressId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
