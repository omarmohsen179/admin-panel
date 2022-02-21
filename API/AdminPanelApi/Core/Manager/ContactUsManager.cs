using AdminPanelApi.Models;

namespace AdminPanelApi.Core.Manager
{
    public class ContactUsManager : Repository<ContactUs, AppDbContext>
    {
        public ContactUsManager(AppDbContext context) : base(context)
        {

        }
    }
}
