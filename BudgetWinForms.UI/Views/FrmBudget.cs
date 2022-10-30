
using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Infraestructure.Models;
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
        private List<Budget> budgets = new List<Budget>();
        public FrmBudget(IArticleRepository articleRepository, ICustomerRepository customerRepository, ICompanyRepository companyRepository, IProjectRepository projectRepository)
        {
            InitializeComponent();
            this.articleRepository = articleRepository;
            this.customerRepository = customerRepository;
            this.companyRepository = companyRepository;
            this.projectRepository = projectRepository;
        }

        private async void FrmBudget_Load(object sender, EventArgs e)
        {
            await ChargeLab();
            await ChargeDtg();
            ChargeResult();
        }

        private async Task ChargeDtg()
        {
            poisonDataGridView1.DataSource = null;
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
            poisonDataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

            SingletonForms.GetForm(FormType.FrmMain).Show();
            this.Hide();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            SingletonForms.GetForm(FormType.FrmArticle).Show();
            await ChargeDtg();
            ChargeResult();
            this.Hide();
        }

        private void ChargeResult()
        {
            var budget = budgets[budgets.Count - 1];
            lblIrr.Text = budget.SumTotal * (40 / 100) + " $";
            lblTotalExpense.Text = budget.SumTotal + " $";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (poisonDataGridView1.Rows.Count > 0)
            {
                string path = string.Empty;
                string get = string.Empty;
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    path = folderBrowserDialog.SelectedPath + "\\";
                    get = folderBrowserDialog.SelectedPath + "\\";
                }

                path = $"{path}presupuesto.xlsx";
                CreateExcelFile.CreateExcelDocument(budgets, path);
                path = String.Empty;
                path = get;
            }

        }
    }
}
