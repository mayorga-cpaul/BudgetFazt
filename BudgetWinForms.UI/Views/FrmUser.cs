using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Infraestructure.Models;
using BudgetFazt.Util.Caché;

namespace BudgetWinForms.UI.Views
{
    public partial class FrmUser : Form
    {
        private readonly IUserRepository userRepository;
        private User user = null!;
        public FrmUser(IUserRepository userRepository)
        {
            InitializeComponent();
            this.userRepository = userRepository;
        }

        private async void FrmUser_Load(object sender, EventArgs e)
        {
            this.Size = new Size(437, 428);
            await Charge();
        }

        private async Task Charge()
        {
            var user = await userRepository.GetAsync(DataOnMemory.UserId);
            this.user = user;
            lblName.Text = user.Name;
        }

        private async void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtConfirmPassword.Texts))
                {
                    throw new Exception("Por favor ingrese su contraseña actual, para confirmar su identidad");
                }

                if (txtOldPassword.Texts.Equals(user.Password))
                {

                }
                else
                {
                    throw new Exception("Lo sentimos, contraseña incorrecta");
                }

                if (txtNewPassword.Texts.Length < 4)
                {
                    throw new Exception("La contraseña debe tener al menos 4 caracteres");
                }

                if (!txtNewPassword.Texts.Equals(txtConfirmPassword.Texts))
                {
                    throw new Exception("Asegurese de confirmar bien la contraseña nueva");
                }

                user.Password = txtConfirmPassword.Texts;
                await userRepository.UpdateAsync(user);
                CleanTextBox();
                MessageBox.Show("Contraseña actualizada correctamente");
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CleanTextBox()
        {
            txtOldPassword.Texts = String.Empty;
            txtNewPassword.Texts = String.Empty;
            txtConfirmPassword.Texts = string.Empty;
        }
    }
}
