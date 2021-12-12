using System;
using AdminPanelApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AdminPanelApi.EntityConfiguration
{
    public class ContactUsConfiguration : IEntityTypeConfiguration<ContactUs>
    {
        public void Configure(EntityTypeBuilder<ContactUs> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Email).IsRequired();
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.Reason).IsRequired();
            builder.Property(b => b.Active).IsRequired().HasDefaultValue(false);
        }
    }
}
