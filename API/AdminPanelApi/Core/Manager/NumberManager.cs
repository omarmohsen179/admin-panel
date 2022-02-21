using AdminPanelApi.Models;
namespace AdminPanelApi.Core.Manager
{
    public class NumberManager : Repository<Number, AppDbContext>
    {
        public NumberManager(AppDbContext context) : base(context)
        {

        }
    }
}
