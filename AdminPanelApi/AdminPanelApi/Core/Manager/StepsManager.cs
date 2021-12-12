
using AdminPanelApi.Models;
namespace AdminPanelApi.Core.Manager
{
    public class StepsManager : Repository<Step, AppDbContext>
    {
        public StepsManager(AppDbContext context) : base(context)
        {

        }
    }
}
