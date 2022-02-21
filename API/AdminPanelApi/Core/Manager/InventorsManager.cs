using AdminPanelApi.Models;

namespace AdminPanelApi.Core.Manager
{
    public class BenefitsManager : Repository<Benefit, AppDbContext>
    {
        public BenefitsManager(AppDbContext context) : base(context)
        {

        }
    }
}
