using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Domain_Layer.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace infrastructure_layer.Configuartions
{
    public class MerchantConfiguration: IEntityTypeConfiguration<Merchant>
    {
        public void Configure(EntityTypeBuilder<Merchant> builder)
        {
            builder.HasKey(m => m.Id);
            builder.ToTable("Merchants");
            builder.Property(m => m.StoreName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(m => m.address);
            builder.Property(m => m.IsActive)
                .IsRequired();
            builder.Property(m => m.CreatedAt);
            builder.Property(m => m.UserId)
                .IsRequired();
            builder.HasOne<ApplicationUser>()
                 .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);
       
    }

    }
}
