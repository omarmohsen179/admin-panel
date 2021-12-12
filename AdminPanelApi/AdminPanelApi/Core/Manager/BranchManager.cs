using AdminPanelApi.Models;

namespace AdminPanelApi.Core.Manager
{
    public class BranchManager : Repository<Branch, AppDbContext>
    {
        public BranchManager(AppDbContext context) : base(context)
        {

        }
    }
}
