using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Util.Caché;
using BudgetWinForms.UI.Settings;
using BudgetWinForms.UI.UControl;

namespace BudgetWinForms.UI.Views
{
    public partial class FrmStart : Form
    {
        private readonly IUserRepository userRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IArticleRepository articleRepository;
        private readonly IProjectRepository projectRepository;
        private readonly ICustomerRepository customerRepository;

        public FrmStart(IUserRepository userRepository, ICompanyRepository companyRepository,
            IArticleRepository articleRepository, IProjectRepository projectRepository, 
            ICustomerRepository customerRepository)
        {
            InitializeComponent();
            this.userRepository = userRepository;
            this.companyRepository = companyRepository;
            this.articleRepository = articleRepository;
            this.projectRepository = projectRepository;
            this.customerRepository = customerRepository;
        }

        private async void FrmStart_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(708, 433);
            await Charge();
        }

        private async Task Charge()
        {
            var result = await projectRepository.GetAllProjects(DataOnMemory.CompanyId);
            flowLayoutPanel1.Controls.Clear();

            var habilitados = result.Where(e => e.State.Equals("Habilitado"));

            foreach (var item in habilitados)
            {
                UCAddBudget uCAddBudget = new UCAddBudget(articleRepository, projectRepository,customerRepository,companyRepository, item.Id, userRepository);
                flowLayoutPanel1.Controls.Add(uCAddBudget);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            SingletonForms.GetForm(FormType.FrmAddProject).ShowDialog();
            await Charge();
        }
    }
}
