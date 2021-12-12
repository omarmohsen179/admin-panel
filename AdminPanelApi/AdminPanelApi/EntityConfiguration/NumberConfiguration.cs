using System;
using AdminPanelApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AdminPanelApi.EntityConfiguration
{
    public class NumberConfiguration : IEntityTypeConfiguration<Number>
    {
        public void Configure(EntityTypeBuilder<Number> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.PhoneNumber).IsRequired();
            builder.HasOne(b => b.Branch).WithMany(b => b.Numbers).HasForeignKey(b => b.BranchId);
        }
    }
}
