using AdminPanelApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminPanelApi.EntityConfiguration
{
    public class SectionImagesConfiguration : IEntityTypeConfiguration<SectionImages>
    {
        public void Configure(EntityTypeBuilder<SectionImages> builder)
        {
            builder.HasKey(builder => builder.SectionId);
            builder.Property(b => b.ImagePath).IsRequired();
            //builder.HasOne(b => b.Section).WithOne(b => b.Image).HasForeignKey<Section>(e=>e.Id);
            
        }
    }
}
