using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Infraestructure.Models;
using BudgetFazt.Util.Caché;
using BudgetWinForms.UI.Settings;

namespace BudgetWinForms.UI.UControl
{
    public partial class UCompany : UserControl
    {
        private readonly ICompanyRepository companyRepository;
        private int companyId;
        private Company Company { get; set; } = null!;

        public UCompany(ICompanyRepository companyRepository, int companyId)
        {
            InitializeComponent();
            this.companyRepository = companyRepository;
            this.companyId = companyId;
        }

        private async void UCompany_Load(object sender, EventArgs e)
        {
            await Charge();
        }
        private async Task Charge()
        {
            Company = await companyRepository.GetAsync(companyId);
            txtName.Text = Company.CompanyName;
        }

        private void UCompany_Click(object sender, EventArgs e)
        {
            DataOnMemory.CompanyId = companyId;
            SingletonForms.GetForm(FormType.FrmMain).Show();
            SingletonForms.GetForm(FormType.FrmCompanies).Hide();
        }
    }
}
