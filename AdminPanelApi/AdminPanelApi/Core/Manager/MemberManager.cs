using AdminPanelApi.Models;

namespace AdminPanelApi.Core.Manager
{
    public class MemberManager : Repository<Member, AppDbContext>
    {
        public MemberManager(AppDbContext context) : base(context)
        {

        }
    }
}
