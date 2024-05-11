using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVAppBusinessLogic;
using System.Security.Cryptography;
using System.Diagnostics;

namespace TVApp
{
    public partial class PasswordForm : Form
    {
        public Password Password { get; set; } = new Password();
        public PasswordForm(AdminForm form)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string source = textBox1.Text;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                string hash = Password.GetHash(sha256Hash, source);
               
                string correcthash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918";

                if (Password.VerifyHash(sha256Hash, source, correcthash))
                {
                    AdminForm adminForm = new AdminForm();
                    this.Hide();
                    adminForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("A jelszó helytelen!", "Hibás jelszó", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
