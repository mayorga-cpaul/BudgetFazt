using BudgetFazt.Infraestructure.Interfaces;
using BudgetWinForms.UI.Settings;
using System.Runtime.InteropServices;

namespace BudgetWinForms.UI.Views
{
    public partial class FrmRegister : Form
    {
        private readonly IUserRepository userRepository;

        public FrmRegister(IUserRepository userRepository)
        {
            InitializeComponent();
            this.userRepository = userRepository;
        }

        private void btnAcessRequest_Click(object sender, EventArgs e)
        {
            SingletonForms.GetForm(FormType.FrmCompanies).Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SingletonForms.GetForm(FormType.FrmLogin).Show();
            this.Hide();
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
    }
}
