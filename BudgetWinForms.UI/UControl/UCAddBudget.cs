using BudgetFazt.Infraestructure.Interfaces;
using BudgetWinForms.UI.Settings;
using BudgetWinForms.UI.Views;

namespace BudgetWinForms.UI.UControl
{
    public partial class UCAddBudget : UserControl
    {
        private IArticleRepository articleRepository;
        public UCAddBudget(IArticleRepository articleRepository)
        {
            InitializeComponent();
            this.articleRepository = articleRepository;
        }

        private void UCAddBudget_Click(object sender, EventArgs e)
        {
            FrmBudget frmBudget = new FrmBudget(articleRepository);
            frmBudget.Show();
            SingletonForms.GetForm(FormType.FrmMain).Hide();
        }
    }
}
