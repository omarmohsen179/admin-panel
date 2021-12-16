using AdminPanelApi.Core.Manager;
using AdminPanelApi.Models;

namespace AdminPanelApi.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }
        private BenefitsManager benefitsManager;

        public BenefitsManager BenefitsManager
        {

            get
            {
                if (benefitsManager == null)
                {
                    benefitsManager = new BenefitsManager(context);
                }
                return benefitsManager;
            }

        }
        private BranchManager branchManager;

        public BranchManager BranchManager
        {

            get
            {
                if (branchManager == null)
                {
                    branchManager = new BranchManager(context);
                }
                return branchManager;
            }

        }
        private ContactUsManager contactUsManager;

        public ContactUsManager ContactUsManager
        {

            get
            {
                if (contactUsManager == null)
                {
                    contactUsManager = new ContactUsManager(context);
                }
                return contactUsManager;
            }

        }
        private MemberManager memberManager;

        public MemberManager MemberManager
        {

            get
            {
                if (memberManager == null)
                {
                    memberManager = new MemberManager(context);
                }
                return memberManager;
            }

        }
        private NumberManager numberManager;

        public NumberManager NumberManager
        {

            get
            {
                if (numberManager == null)
                {
                    numberManager = new NumberManager(context);
                }
                return numberManager;
            }

        }
        private SectionImagesManager sectionImagesManager;

        public SectionImagesManager SectionImagesManager
        {

            get
            {
                if (sectionImagesManager == null)
                {
                    sectionImagesManager = new SectionImagesManager(context);
                }
                return sectionImagesManager;
            }


        }
        private SectionManager sectionManager;

        public SectionManager SectionManager
        {

            get
            {
                if (sectionManager == null)
                {
                    sectionManager = new SectionManager(context);
                }
                return sectionManager;
            }

        }
        private StepsManager stepsManager;

        public StepsManager StepsManager
        {

            get
            {
                if (stepsManager == null)
                {
                    stepsManager = new StepsManager(context);
                }
                return stepsManager;
            }

        }
        private TextManager textManager;

        public TextManager TextManager
        {

            get
            {
                if (textManager == null)
                {
                    textManager = new TextManager(context);
                }
                return textManager;
            }

        }
        private InventorsManager inventorsManager;

        public InventorsManager InventorsManager
        {

            get
            {
                if (inventorsManager == null)
                {
                    inventorsManager = new InventorsManager(context);
                }
                return inventorsManager;
            }

        }
    }
}
