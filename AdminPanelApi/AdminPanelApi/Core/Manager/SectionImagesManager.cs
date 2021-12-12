
using AdminPanelApi.Models;
namespace AdminPanelApi.Core.Manager
{
    public class SectionImagesManager : Repository<Section, AppDbContext>
    {
        public SectionImagesManager(AppDbContext context) : base(context)
        {

        }
    }
}
