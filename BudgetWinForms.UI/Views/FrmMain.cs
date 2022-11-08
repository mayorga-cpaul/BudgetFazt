using BudgetFazt.Infraestructure.Interfaces;
using BudgetWinForms.UI.Settings;
using System.Runtime.InteropServices;

namespace BudgetWinForms.UI.Views
{
    public partial class FrmMain : Form
    {
        private readonly IUserRepository userRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IArticleRepository articleRepository;
        private readonly IProjectRepository projectRepository;
        private readonly ICustomerRepository customerRepository;

        public FrmMain(IUserRepository userRepository, ICompanyRepository companyRepository, 
            IArticleRepository articleRepository, IProjectRepository projectRepository, ICustomerRepository customerRepository)
        {
            InitializeComponent();
            this.userRepository = userRepository;
            this.companyRepository = companyRepository;
            this.articleRepository = articleRepository;
            this.projectRepository = projectRepository;
            this.customerRepository = customerRepository;
        }

        private void AbrirFormEnPanel(object formHijo)
        {
            if (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);


            Form fh = (Form)formHijo;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(fh);
            this.panel1.Tag = fh;
            fh.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(864, 481);
            AbrirFormEnPanel(SingletonForms.GetForm(FormType.FrmStart));
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(SingletonForms.GetForm(FormType.FrmStart));
        }

        private void BtnBudget_Click(object sender, EventArgs e)
        {
            SingletonForms.GetForm(FormType.FrmCompanies).Show();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void panelButtons_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
