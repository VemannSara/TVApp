using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVApp
{
    public partial class NevBekeres : Form
    {
        public Form1 form1 = new Form1();
        public TextBox TextBox1 => textBox1;
        public string nev => textBox1.Text;      
       
        public NevBekeres()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string nev;
            //nev = textBox1.Text;
            form1.Label8.Text = "Szia " + nev + " !";
            form1.Nev = nev;
            this.Hide();
            form1.ShowDialog();
            this.Close();
        }
    }
}
