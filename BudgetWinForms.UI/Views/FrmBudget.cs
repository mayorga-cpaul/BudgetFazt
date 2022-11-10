
using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Util.Caché;
using BudgetFazt.Util.Processes;
using BudgetWinForms.UI.Settings;
using ExportToExcel;

namespace BudgetWinForms.UI.Views
{
    public partial class FrmBudget : Form
    {
        private readonly IArticleRepository articleRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IProjectRepository projectRepository;
        private readonly IUserRepository userRepository;
        private List<Budget> budgets = new List<Budget>();
        
        public FrmBudget(IArticleRepository articleRepository, ICustomerRepository customerRepository, 
            ICompanyRepository companyRepository, 
            IProjectRepository projectRepository, IUserRepository userRepository)
        {
            InitializeComponent();
            this.articleRepository = articleRepository;
            this.customerRepository = customerRepository;
            this.companyRepository = companyRepository;
            this.projectRepository = projectRepository;
            this.userRepository = userRepository;
        }

        private async void FrmBudget_Load(object sender, EventArgs e)
        {
            SingletonForms.GetForm(FormType.FrmMain).Hide();

            this.MinimumSize = new Size(823, 559);
            await ChargeLab();
            await ChargeDtg();
            ChargeResult();
        }

        private async Task ChargeDtg()
        {
            poisonDataGridView1.DataSource = null;

            if (poisonDataGridView1.Rows.Count > 0)
            {
                poisonDataGridView1.Rows.Clear();
            }

            budgets = CalculusBudget.GetBudget((await articleRepository.GetAllArticles(DataOnMemory.ProjectId)).ToList());
            poisonDataGridView1.DataSource = budgets;

            poisonDataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            poisonDataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            poisonDataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            poisonDataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            poisonDataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            poisonDataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            poisonDataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            poisonDataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            poisonDataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private async Task ChargeLab()
        {
            var company = await companyRepository.GetAsync(DataOnMemory.CompanyId);
            var customer = await customerRepository.GetAsync(DataOnMemory.ProjectId);
            var project = await projectRepository.GetAsync(DataOnMemory.ProjectId);

            lblClientName.Text = customer.Name;
            lblClientPhone.Text = customer.Phone;
            lblClientAdress.Text = customer.Address;

            lblCompanyAddress.Text = company.Address;
            lblCompanyName.Text = company.CompanyName;
            lblCompanyPhone.Text = company.Phone;

            lblIinicio.Text = project.StartDate.ToShortDateString();
            lblFin.Text = project.EndDate.ToShortDateString();
        }

        private void nightButton1_Click(object sender, EventArgs e)
        {
            //var tst = new FrmMain(userRepository, companyRepository, articleRepository, projectRepository, customerRepository);
            //tst.Show();
            SingletonForms.GetForm(FormType.FrmMain).Show();
            this.Dispose();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            SingletonForms.GetForm(FormType.FrmArticle).ShowDialog();
            await ChargeDtg();
            ChargeResult();
        }

        private void ChargeResult()
        {
            if (budgets.Count == 0)
            {
                return;
            }
            var budget = budgets[budgets.Count - 1];
            var result = budget.SumTotal*0.40;
            lblIrr.Text =  Math.Round(result, 2) + " $";
            lblTotalExpense.Text = budget.SumTotal + " $";
        }

        private void btnExport_Click_1(object sender, EventArgs e)
        {
            try
            {
                string path = string.Empty;
                string data = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

                path = $"{data}\\presupuesto.xlsx";
                CreateExcelFile.CreateExcelDocument(budgets, path);
                path = String.Empty;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar el archivo", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {

                int id = 0;
                if ((int)poisonDataGridView1.Rows.Count > 0)
                    id = id = (int)poisonDataGridView1.Rows[poisonDataGridView1.CurrentRow.Index].Cells[0].Value;
                else
                    return;

                if (id == 0)
                {
                    return;
                }

                await articleRepository.DeleteAsync(id);

                await ChargeDtg();
                ChargeResult();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
