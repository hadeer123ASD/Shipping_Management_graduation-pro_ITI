using Domain_Layer.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace infrastructure_layer.Configuartions
{
    public class EmployeeConfiguration:IEntityTypeConfiguration<Employee>
    {

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(a => a.Id);
            builder.ToTable("Employees");
            builder.Property(a => a.UserId)
                .IsRequired();
            builder.HasOne<ApplicationUser>()
                 .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
