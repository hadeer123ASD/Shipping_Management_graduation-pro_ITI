using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain_Layer.Users;

namespace infrastructure_layer.Configuartions
{
    public class CourierConfiguration : IEntityTypeConfiguration<Courier>
    {
        public void Configure(EntityTypeBuilder<Courier> builder)
        {
            builder.HasKey(a => a.Id);
            builder.ToTable("Couriers");
            builder.Property(a => a.UserId)
                .IsRequired();
            builder.HasOne<ApplicationUser>()
                 .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
