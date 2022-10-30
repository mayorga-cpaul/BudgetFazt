﻿using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Infraestructure.Models;
using BudgetFazt.Infraestructure.Repositories;
using BudgetFazt.Util.Caché;
using BudgetWinForms.UI.Settings;
using System.Runtime.InteropServices; 

namespace BudgetWinForms.UI.Views
{
    public partial class FrmAddCompany : Form
    {
        private readonly ICompanyRepository companyRepositor;

        public FrmAddCompany(ICompanyRepository companyRepositor)
        {
            InitializeComponent();
            this.companyRepositor = companyRepositor;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelButtons_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private async void btnAddCompany_Click(object sender, EventArgs e)
        {
            Company company = new Company()
            {
                UserId = DataOnMemory.UserId,
                CompanyName = txtCompanyName.Texts,
                Description = txtDescription.Texts,
                Phone = txtPhone.Texts,
                Address = txtAddress.Texts,
            };

            await companyRepositor.CreateAsync(company);
            DataOnMemory.CompanyId = await companyRepositor.LastCretedIndex();
            SingletonForms.GetForm(FormType.FrmMain).Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SingletonForms.GetForm(FormType.FrmCompanies).Show();
            this.Hide();
        }
    }
}
