using System;
using AdminPanelApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminPanelApi.EntityConfiguration
{
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Active).IsRequired().HasDefaultValue(false);
            builder.HasMany(b => b.Numbers).WithOne(b => b.Branch).HasForeignKey(b => b.BranchId);
        }
    }

}
