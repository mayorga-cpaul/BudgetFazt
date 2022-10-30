
using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Infraestructure.Models;
using BudgetWinForms.UI.Settings;
using ReaLTaiizor.Controls;

namespace BudgetWinForms.UI.Views
{
    public partial class FrmBudget : Form
    {
        private readonly IArticleRepository articleRepository;
        public FrmBudget(IArticleRepository articleRepository)
        {
            InitializeComponent();
            this.articleRepository = articleRepository;
        }

        private void FrmBudget_Load(object sender, EventArgs e)
        {
            ChargeDtg();
        }

        private void ChargeDtg()
        {
            poisonDataGridView1.DataSource = null;
            poisonDataGridView1.DataSource = new List<Article>() { new Article() { Name = "ADASDASD" }, new Article() { Name = "ADASDASD" } };

            poisonDataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            poisonDataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            poisonDataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            poisonDataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            poisonDataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            poisonDataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            poisonDataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void nightButton1_Click(object sender, EventArgs e)
        {
            SingletonForms.GetForm(FormType.FrmMain).Show();
            this.Hide();
        }
    }
}
