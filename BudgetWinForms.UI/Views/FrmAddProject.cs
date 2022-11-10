using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Infraestructure.Models;
using BudgetFazt.Util.Caché;
using BudgetWinForms.UI.Helper;
using BudgetWinForms.UI.Settings;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.EntityFrameworkCore.Internal;

namespace BudgetWinForms.UI.Views
{
    public partial class FrmAddProject : Form
    {
        private readonly IUserRepository userRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IArticleRepository articleRepository;
        private readonly IProjectRepository projectRepository;
        private readonly ICustomerRepository customerRepository;

        public FrmAddProject(IUserRepository userRepository, ICompanyRepository companyRepository, IArticleRepository articleRepository,
            IProjectRepository projectRepository, ICustomerRepository customerRepository)
        {
            InitializeComponent();
            this.userRepository = userRepository;
            this.companyRepository = companyRepository;
            this.articleRepository = articleRepository;
            this.projectRepository = projectRepository;
            this.customerRepository = customerRepository;
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
        }

        private void nightButton1_Click(object sender, EventArgs e)
        {
            SingletonForms.GetForm(FormType.FrmMain).Show();
            this.Hide();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorMessage.ValidateProject(txtName.Texts, txtDescription.Texts, dtStart.Value, dtEnd.Value);

                if (CustomerOnMemory.Name.Equals(String.Empty))
                {
                    throw new Exception("Por favor agregue los datos del cliente");
                }

                if (CustomerOnMemory.Phone.Equals(String.Empty))
                {
                    throw new Exception("Por favor agregue los datos del cliente");
                }

                if (CustomerOnMemory.Email.Equals(String.Empty))
                {
                    throw new Exception("Por favor agregue los datos del cliente");
                }

                if (CustomerOnMemory.Address.Equals(String.Empty))
                {
                    throw new Exception("Por favor agregue los datos del cliente");
                }


                Project project = new Project()
                {
                    CompanyId = DataOnMemory.CompanyId,
                    NameProject = txtName.Texts,
                    Description = txtDescription.Texts,
                    StartDate = dtStart.Value,
                    EndDate = dtEnd.Value,
                    State = "Habilitado",
                };
                Clean();
                await projectRepository.CreateAsync(project);

                Customer customer = new Customer()
                {
                    Id = await projectRepository.LastCretedIndex(),
                    CompanyId = DataOnMemory.CompanyId,
                    Name = CustomerOnMemory.Name,
                    Phone = CustomerOnMemory.Phone,
                    Email = CustomerOnMemory.Email,
                    Address = CustomerOnMemory.Address,
                };

                await customerRepository.CreateAsync(customer);

                SingletonForms.GetForm(FormType.FrmMain).Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clean()
        {
            txtName.Texts = string.Empty;
            txtDescription.Texts = string.Empty;
        }

        private void FrmAddProject_Load(object sender, EventArgs e)
        {
            SingletonForms.GetForm(FormType.FrmMain).Hide();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            SingletonForms.GetForm(FormType.FrmAddCustomer).ShowDialog();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            ErrorMessage.OnlyLetters(e);
        }
    }
}
