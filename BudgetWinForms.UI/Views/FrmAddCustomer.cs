using BudgetFazt.Infraestructure.Interfaces;

namespace BudgetWinForms.UI.Views
{
    public partial class FrmAddCustomer : Form
    {
        private readonly IUserRepository userRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IArticleRepository articleRepository;
        private readonly IProjectRepository projectRepository;
        private readonly ICustomerRepository customerRepository;

        public FrmAddCustomer(IUserRepository userRepository, ICompanyRepository companyRepository, IArticleRepository articleRepository, 
            IProjectRepository projectRepository, ICustomerRepository customerRepository)
        { 
            InitializeComponent();
            this.userRepository = userRepository;
            this.companyRepository = companyRepository;
            this.articleRepository = articleRepository;
            this.projectRepository = projectRepository;
            this.customerRepository = customerRepository;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void nightButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
