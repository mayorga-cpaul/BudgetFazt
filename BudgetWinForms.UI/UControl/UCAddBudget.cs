using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Util.Caché;
using BudgetWinForms.UI.Settings;
using BudgetWinForms.UI.Views;

namespace BudgetWinForms.UI.UControl
{
    public partial class UCAddBudget : UserControl
    {
        private readonly IArticleRepository articleRepository;
        private readonly IProjectRepository projectRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly ICompanyRepository companyRepository;

        private int projectId;
        public UCAddBudget(IArticleRepository articleRepository, IProjectRepository projectRepository, ICustomerRepository customerRepository,
            ICompanyRepository companyRepository, int projectId)
        {
            InitializeComponent();
            this.articleRepository = articleRepository;
            this.projectRepository = projectRepository;
            this.customerRepository = customerRepository;
            this.companyRepository = companyRepository;
            this.projectId = projectId;
        }

        private void UCAddBudget_Click(object sender, EventArgs e)
        {
            DataOnMemory.ProjectId = projectId;
            FrmBudget frmBudget = new FrmBudget(articleRepository, customerRepository, companyRepository, projectRepository);
            frmBudget.Show();
            SingletonForms.GetForm(FormType.FrmMain).Hide();
        }

        private async Task Charge()
        {
            var result = await projectRepository.GetAsync(projectId);
            lblName.Text = result.NameProject;
        }

        private async void UCAddBudget_Load(object sender, EventArgs e)
        {
            await Charge();
        }
    }
}
