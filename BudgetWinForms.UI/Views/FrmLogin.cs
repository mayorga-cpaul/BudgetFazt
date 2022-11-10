using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Util.Caché;
using BudgetWinForms.UI.Settings;
using System.Runtime.InteropServices;

namespace BudgetWinForms.UI.Views
{
    public partial class FrmLogin : Form
    {
        // Esto es el repostorio se ocupará en este formulario
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
            try
            {
                if (await userRepository.ExistOnDb(txtEmail.Texts))
                {
                    if (await userRepository.AccessToAppAsync(txtEmail.Texts, txtPassword.Texts))
                    {
                        var user = await userRepository.GetByEmailPassword(txtEmail.Texts, txtPassword.Texts);
                        DataOnMemory.UserId = user.Id;
                        SingletonForms.GetForm(FormType.FrmCompanies).Show();
                        SingletonForms.GetForm(FormType.FrmLogin).Hide();
                        Textboxs();
                    }
                    else
                    {
                        throw new Exception("Contraseña incorrecta");
                    }
                }
                else
                {
                    throw new Exception($"Este email: {txtEmail.Texts} no se ha registrado en el sistema");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Textboxs()
        {
            txtEmail.Texts = string.Empty;
            txtPassword.Texts = string.Empty;
        }

        private void btnNewUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SingletonForms.GetForm(FormType.FrmRegister).Show();
            this.Hide();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(808, 481);
        }
    }
}