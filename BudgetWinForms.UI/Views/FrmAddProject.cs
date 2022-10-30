using BudgetFazt.Infraestructure.Interfaces;
using BudgetWinForms.UI.Settings;

namespace BudgetWinForms.UI.Views
{
    public partial class FrmAddProject : Form
    {
        private readonly IUserRepository userRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IArticleRepository articleRepository;
        private readonly IProjectRepository projectRepository;
        private readonly ICustomerRepository customerRepository;

        public FrmAddProject(IUserRepository userRepository, ICompanyRepository companyRepository, IArticleRepository articleRepository,
            IProjectRepository projectRepository, ICustomerRepository customerRepository)
        {
            InitializeComponent();
            this.userRepository = userRepository;
            this.companyRepository = companyRepository;
            this.articleRepository = articleRepository;
            this.projectRepository = projectRepository;
            this.customerRepository = customerRepository;
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
        }

        private void nightButton1_Click(object sender, EventArgs e)
        {
            SingletonForms.GetForm(FormType.FrmMain).Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SingletonForms.GetForm(FormType.FrmMain).Show();
            this.Hide();
        }
    }
}
