using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Infraestructure.Models;

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

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Article article = new Article()
            {
                
                Name = txtArticleName.Texts,
                UnitPrice = double.Parse(txtUnitPrice.Texts),
                Quantity = int.Parse(txtQuantity.Texts),
                Description = txtDescription.Texts,
                Discount = double.Parse(txtDescuento.Texts),
            };
            articleRepository.SetArticle(article);
        }

        private void nightButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
