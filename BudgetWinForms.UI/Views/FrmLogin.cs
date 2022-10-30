using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Util.Caché;
using BudgetWinForms.UI.Settings;
using System.Runtime.InteropServices;

namespace BudgetWinForms.UI.Views
{
    public partial class FrmLogin : Form
    {
        private readonly IUserRepository userRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IArticleRepository articleRepository;
        private readonly IProjectRepository projectRepository;
        private readonly ICustomerRepository customerRepository;

        public FrmLogin(IUserRepository userRepository, ICompanyRepository companyRepository,
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

        #region MouseDownPanels

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #endregion
        private void panelButtons_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnAcessRequest_Click(object sender, EventArgs e)
        {
            if (await userRepository.AccessToAppAsync(txtEmail.Texts, txtPassword.Texts))
            {
                var user = await userRepository.GetByEmailPassword(txtEmail.Texts, txtPassword.Texts);
                DataOnMemory.UserId = user.Id;
                SingletonForms.GetForm(FormType.FrmCompanies).Show();
                SingletonForms.GetForm(FormType.FrmLogin).Hide();

            }else
            {
                MessageBox.Show("Error al iniciar sesión, verifica tu contraseña", "Error");
            }
        }

        private void btnNewUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SingletonForms.GetForm(FormType.FrmRegister).Show();
            this.Hide();
        }
    }
}
