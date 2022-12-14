using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Util.Caché;
using BudgetWinForms.UI.Settings;
using BudgetWinForms.UI.UControl;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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
            Application.Exit();
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

        private async void FrmCompanies_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(808, 481);
            await Charge();
        }

        private async Task Charge()
        {
            flowLayoutPanel1.Controls.Clear();
            var companies = await companyRepository.GetCompanies(DataOnMemory.UserId);

            foreach (var item in companies)
            {
                UCompany uCompany = new UCompany(companyRepository, item.Id);
                uCompany.userRepository = userRepository;
                uCompany.articleRepository = articleRepository;
                uCompany.projectRepository = projectRepository;
                uCompany.customerRepository = customerRepository;
                flowLayoutPanel1.Controls.Add(uCompany);
            }
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            SingletonForms.GetForm(FormType.FrmUser).ShowDialog();
        }

        private void btnCreate_MouseEnter(object sender, EventArgs e)
        {
            btnCreate.BackColor = Color.FromArgb(40, 153, 192);
        }

        private void btnCreate_MouseLeave(object sender, EventArgs e)
        {
            btnCreate.BackColor = Color.Ivory;
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(40, 153, 192);
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Ivory;
        }
    }
}
