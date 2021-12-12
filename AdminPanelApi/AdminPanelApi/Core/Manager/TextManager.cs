using AdminPanelApi.Models;

namespace AdminPanelApi.Core.Manager
{
    public class TextManager : Repository<Text, AppDbContext>
    {
        public TextManager(AppDbContext context) : base(context)
        {

        }
    }
}
