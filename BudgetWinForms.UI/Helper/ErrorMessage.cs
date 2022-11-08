using Microsoft.EntityFrameworkCore.Diagnostics;
using RJCodeAdvance.RJControls;

namespace BudgetWinForms.UI.Helper
{
    public static class ErrorMessage
    {
        public static void PhoneValidation(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            if (e.KeyChar.Equals("-"))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        public static void OnlyLetters(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        public static void OnlyNumbers(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        public static void ValidateStringEmpty(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                throw new Exception("Por favor rellene los campos necesarios");
            }
        }
        public static void ValidateDecimalNegative(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
                {
                    e.Handled = true;
                }
                // solo 1 punto decimal
                if ((e.KeyChar == '.') && ((sender as RJTextBox).Texts.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
                if ((e.KeyChar == '-') && ((sender as RJTextBox).Texts.IndexOf('-') > -1))
                {
                    e.Handled = true;
                }
                if ((sender as RJTextBox).Texts.Length > 0 && (e.KeyChar == '-') && (sender as RJTextBox).Texts.ToCharArray()[0] != '-')
                {
                    e.Handled = true;
                }
                if ((sender as RJTextBox).Texts.Contains(".") && (char)Keys.Back != e.KeyChar)
                {
                    if ((sender as RJTextBox).Texts.Substring((sender as RJTextBox).Texts.IndexOf('.')).Length > 4)
                    {
                        e.Handled = true;
                    }
                }
                else
                if ((sender as RJTextBox).Texts.Length > 9 && (char)Keys.Back != e.KeyChar && '.' != e.KeyChar)
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public static void ValidateArticle(double unitPrice, int quantity, double discount) 
        {
            if (unitPrice <= 0)
            {
                throw new Exception("El precio unitario debe ser mayor a cero");
            }

            if (quantity <= 0)
            {
                throw new Exception("La cantidad debe ser mayor a cero");
            }

            if (discount <= 0 || discount >= 100)
            {
                throw new Exception("El descuento tiene que estár dentro del 99%");
            }
        }

        public static void ValidateProject(string name, string description, DateTime start, DateTime end)
        {
            ValidateStringEmpty(name);
            ValidateStringEmpty(description);

            if (start > end)
            {
                throw new Exception("Por favor seleccione una fecha correcta");
            }
        }
    }
}
