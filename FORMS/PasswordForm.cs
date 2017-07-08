using System;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Controles2016
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            /*var pass = "5C85BB36F3869809FB738A3BA6F990AEDBFECA3DF2DC1A997FA49C50D0EED8E6";
            if (tbPass.Text == "Password" | tbPass.Text == "")
            {
                MessageBox.Show("Debe ingresar un password");
            }
            else
            {
                var hash = hashea(tbPass.Text);
            //    if (hash == pass)
            if (true)
                {
                    ReportView form3 = new ReportView();
                    form3.Show();
                    Dispose();
                }
                else
                {
                    MessageBox.Show("Password incorrecto");
                    tbPass.SelectAll();
                }
            }*/
            ReportView form3 = new ReportView();
            form3.Show();
            Dispose();
        }
        internal static string hashea(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            using (var sha = new SHA256Managed())
            {
                byte[] textData = Encoding.UTF8.GetBytes(text);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", string.Empty);
            }
        }
    }
}
