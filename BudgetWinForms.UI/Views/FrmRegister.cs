using BudgetFazt.Infraestructure.Interfaces;
using BudgetFazt.Infraestructure.Models;
using BudgetFazt.Util.Caché;
using BudgetWinForms.UI.Helper;
using BudgetWinForms.UI.Settings;
using System.Runtime.InteropServices;

namespace BudgetWinForms.UI.Views
{
    public partial class FrmRegister : Form
    {
        // Repositorio usuario donde almacenas todos los metodos en especial CRUD
        private readonly IUserRepository userRepository;

        public FrmRegister(IUserRepository userRepository)
        {
            // Inicializa componentes de C# controles etc
            InitializeComponent();
           
            // cargas repositorio
            this.userRepository = userRepository;
        }

        private async void btnAcessRequest_Click(object sender, EventArgs e)
        {
            try
            {
                // Creas un usuario ya que se está registrando

                ErrorMessage.ValidateStringEmpty(txtEmail.Texts);
                ErrorMessage.ValidateStringEmpty(txtName.Texts);

                if (txtPassword.Texts.Length <= 3)
                {
                    throw new Exception("La contraseña debe tener al menos 4 caracteres");
                }

                // Verifica que no exista ese email
                if (await userRepository.ExistOnDb(txtEmail.Texts))
                {
                    throw new Exception("Este email ya se ha registrado, por favor utilice otro");
                }

                // Verifica que no exista ese email
                if (await userRepository.ExistName(txtName.Texts))
                {
                    throw new Exception("Este nombre ya se ha registrado, por favor utilice otro");
                }

                User user = new User()
                {
                    Name = txtName.Texts,
                    Email = txtEmail.Texts,
                    Password = txtPassword.Texts,
                };

                // Lo agregas a la base de datos
                await userRepository.CreateAsync(user);

                // Obtienes el Id del último registro
                DataOnMemory.UserId = await userRepository.LastCretedIndex();

                // Mensaje de creación de usuario
                MessageBox.Show("Usuario creado correctamente");

                // Abres el login para que acceda
                SingletonForms.GetForm(FormType.FrmLogin).Show();

                // Este metodo cierra este formulario
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Abre el form login
            SingletonForms.GetForm(FormType.FrmLogin).Show();
            this.Hide();
        }

        // Para darle funcionalidad a panel para dar movilidad a formulario register
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelButtons_MouseDown(object sender, MouseEventArgs e)
        {
            // se activa el evento mouse down para mover dicho form
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(808, 481);
        }
    }
}
