using BudgetFazt.Infraestructure.Enums;
using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Infraestructure.Models;
using BudgetFazt.Util.Caché;
using BudgetWinForms.UI.Settings;

namespace BudgetWinForms.UI.Views
{
    public partial class FrmArticle : Form
    {
        private readonly IUserRepository userRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IArticleRepository articleRepository;

        public FrmArticle(IUserRepository userRepository, ICompanyRepository companyRepository,
            IArticleRepository articleRepository)
        {
            InitializeComponent();
            this.userRepository = userRepository;
            this.companyRepository = companyRepository;
            this.articleRepository = articleRepository;
        }

        private void FrmArticle_Load(object sender, EventArgs e)
        {
            cmbQuality.Items.AddRange(Enum.GetValues(typeof(Quality)).Cast<object>().ToArray());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Article article = new Article()
            {
                ProjectId = DataOnMemory.ProjectId,
                Name = txtArticleName.Texts,
                UnitPrice = double.Parse(txtUnitPrice.Texts),
                Quantity = int.Parse(txtQuantity.Texts),
                Description = txtDescription.Texts,
                Quality = cmbQuality.SelectedItem.ToString(),
                Discount = double.Parse(txtDescuento.Texts),
            };

            articleRepository.CreateAsync(article);
        }

        private void nightButton1_Click(object sender, EventArgs e)
        {
            SingletonForms.GetForm(FormType.FrmBudget).Show();
            this.Hide();
        }
    }
}
