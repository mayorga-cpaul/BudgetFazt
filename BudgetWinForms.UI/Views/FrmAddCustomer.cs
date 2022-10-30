using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Infraestructure.Models;
using BudgetFazt.Util.Caché;
using BudgetWinForms.UI.Settings;

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
            CustomerOnMemory.Name = txtName.Texts;
            CustomerOnMemory.Email = txtEmail.Texts;
            CustomerOnMemory.Phone = txtPhone.Texts;
            CustomerOnMemory.Address = txtAddress.Texts;

            SingletonForms.GetForm(FormType.FrmAddProject).Show();
            SingletonForms.GetForm(FormType.FrmAddCustomer).Hide();
        }

        private void nightButton1_Click(object sender, EventArgs e)
        {
            SingletonForms.GetForm(FormType.FrmAddProject).Show();
            SingletonForms.GetForm(FormType.FrmAddCustomer).Hide();
        }
    }
}
