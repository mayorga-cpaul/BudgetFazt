using BudgetFazt.Infraestructure.Interfaces;
using BudgetWinForms.UI.Settings;

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
            AbrirFormEnPanel(SingletonForms.GetForm(FormType.FrmStart));
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(SingletonForms.GetForm(FormType.FrmStart));
        }
    }
}
