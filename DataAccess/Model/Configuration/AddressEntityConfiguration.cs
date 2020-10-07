using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Model.Configuration
{
    public class AddressEntityConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("address", "dbo");
            builder.HasKey(e => e.Id).HasName("PK__address__3213E83FB1CEDF89");
            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.StreetAndNumber).HasColumnName("street_and_number");
            builder.Property(e => e.State).HasColumnName("state");
            builder.Property(e => e.City).HasColumnName("city");
            builder.Property(e => e.ZipCode).HasColumnName("zip_code");

        }
    }
}
