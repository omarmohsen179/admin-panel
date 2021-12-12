using System;
using AdminPanelApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminPanelApi.EntityConfiguration
{
    public class MemeberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.MemberName).IsRequired();
            builder.Property(b => b.MemberNameEn).IsRequired();
            builder.Property(b => b.Active).IsRequired().HasDefaultValue(false);
        }
    }
}
