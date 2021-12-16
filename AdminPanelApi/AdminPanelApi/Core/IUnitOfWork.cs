using AdminPanelApi.Core.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelApi.Core
{
  public  interface IUnitOfWork
    {
        BenefitsManager BenefitsManager { get; }
        BranchManager BranchManager { get; }
        ContactUsManager ContactUsManager { get; }
        MemberManager MemberManager { get; }
        NumberManager NumberManager { get; }
        SectionImagesManager SectionImagesManager { get; }
        SectionManager SectionManager { get; }
        StepsManager StepsManager { get; }
        TextManager TextManager { get; }
        InventorsManager InventorsManager { get; }
    }
}
