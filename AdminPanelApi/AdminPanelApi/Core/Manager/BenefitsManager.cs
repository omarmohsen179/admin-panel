using AdminPanelApi.Models;

namespace AdminPanelApi.Core.Manager
{
    public class InventorsManager : Repository<Inventor, AppDbContext>
    {
        public InventorsManager(AppDbContext context) : base(context)
        {

        }
    }
}
