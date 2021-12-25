
using AdminPanelApi.Models;
namespace AdminPanelApi.Core.Manager
{
    public class SectionImagesManager : Repository<SectionImages, AppDbContext>
    {
        public SectionImagesManager(AppDbContext context) : base(context)
        {

        }
    }
}
