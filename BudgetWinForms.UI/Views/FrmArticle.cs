using BudgetFazt.Infraestructure.Enums;
using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Infraestructure.Models;
using BudgetFazt.Util.Caché;
using BudgetWinForms.UI.Helper;
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
            try
            {
                if (cmbQuality.SelectedIndex < 0)
                {
                    throw new Exception("Por favor selecciona la calidad del producto");
                }
                ErrorMessage.ValidateArticle(double.Parse(txtUnitPrice.Texts), int.Parse(txtQuantity.Texts), double.Parse(txtDescuento.Texts));

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
                Clean();
                articleRepository.CreateAsync(article);
                SingletonForms.GetForm(FormType.FrmBudget).Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clean()
        {
            txtArticleName.Texts = string.Empty;
            txtDescription.Texts = string.Empty;
            txtDescuento.Texts = string.Empty;
            txtQuantity.Texts = string.Empty;
            txtUnitPrice.Texts = string.Empty;
            cmbQuality.SelectedIndex = 1;
        }
        private void nightButton1_Click(object sender, EventArgs e)
        {
            SingletonForms.GetForm(FormType.FrmBudget).Show();
            this.Hide();
        }

        private void txtArticleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrorMessage.OnlyLetters(e);
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrorMessage.OnlyNumbers(e);
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrorMessage.OnlyNumbers(e);
        }
    }
}
