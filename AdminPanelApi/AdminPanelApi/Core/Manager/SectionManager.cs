
using AdminPanelApi.Models;
namespace AdminPanelApi.Core.Manager
{
    public class SectionManager : Repository<Section, AppDbContext>
    {
        public SectionManager(AppDbContext context) : base(context)
        {

        }
    }
}
