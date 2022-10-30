﻿using BudgetFazt.Infraestructure.Interfaces;
using BudgetWinForms.UI.Settings;
using BudgetWinForms.UI.UControl;

namespace BudgetWinForms.UI.Views
{
    public partial class FrmStart : Form
    {
        private readonly IUserRepository userRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IArticleRepository articleRepository;
        private readonly IProjectRepository projectRepository;
        private readonly ICustomerRepository customerRepository;

        public FrmStart(IUserRepository userRepository, ICompanyRepository companyRepository,
            IArticleRepository articleRepository, IProjectRepository projectRepository, 
            ICustomerRepository customerRepository)
        {
            InitializeComponent();
            this.userRepository = userRepository;
            this.companyRepository = companyRepository;
            this.articleRepository = articleRepository;
            this.projectRepository = projectRepository;
            this.customerRepository = customerRepository;
        }

        private void FrmStart_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 50; i++)
            {
                UCAddBudget uCAddBudget = new UCAddBudget(articleRepository);
                flowLayoutPanel1.Controls.Add(uCAddBudget);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SingletonForms.GetForm(FormType.FrmAddProject).Show();
            SingletonForms.GetForm(FormType.FrmMain).Hide();

        }
    }
}
