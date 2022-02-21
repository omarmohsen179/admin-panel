using AdminPanelApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminPanelApi.EntityConfiguration
{
    public class RequestConfiguration : IEntityTypeConfiguration<Requests>
    {
        public void Configure(EntityTypeBuilder<Requests> builder)
        {
            builder.HasKey(b => b.Id);
        }
    }
}
