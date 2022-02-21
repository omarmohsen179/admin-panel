using System;
using AdminPanelApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AdminPanelApi.EntityConfiguration
{
    public class TextConfiguration : IEntityTypeConfiguration<Text>
    {
        public void Configure(EntityTypeBuilder<Text> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Content).IsRequired();
            builder.HasOne(b => b.Section).WithMany(b => b.Text).HasForeignKey(b => b.SectionId);

        }
    }
}
