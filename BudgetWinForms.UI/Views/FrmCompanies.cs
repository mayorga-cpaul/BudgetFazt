using BudgetFazt.Infraestructure.Interfaces;
using BudgetWinForms.UI.Settings;
using System.Runtime.InteropServices;

namespace BudgetWinForms.UI.Views
{
    public partial class FrmCompanies : Form
    {
        private readonly IUserRepository userRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IArticleRepository articleRepository;
        private readonly IProjectRepository projectRepository;
        private readonly ICustomerRepository customerRepository;

        public FrmCompanies(IUserRepository userRepository, ICompanyRepository companyRepository, IArticleRepository articleRepository,
            IProjectRepository projectRepository, ICustomerRepository customerRepository)
        {
            InitializeComponent();
            this.userRepository = userRepository;
            this.companyRepository = companyRepository;
            this.articleRepository = articleRepository;
            this.projectRepository = projectRepository;
            this.customerRepository = customerRepository;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SingletonForms.GetForm(FormType.FrmLogin).Show();
            this.Hide();
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelButtons_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            SingletonForms.GetForm(FormType.FrmAddCompany).Show();
            this.Hide();
        }

        private void FrmCompanies_Load(object sender, EventArgs e)
        {

        }
    }
}
