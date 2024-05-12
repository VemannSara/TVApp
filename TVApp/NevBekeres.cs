namespace TVApp
{
    public partial class NevBekeres : Form
    {
        private Form1 form1 = new Form1();
        private string Nev => textBox1.Text;      
       
        public NevBekeres()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1.Label8.Text = "Szia " + Nev + " !";
            form1.Nev = Nev;
            this.Hide();
            form1.ShowDialog();
            this.Close();
        }
    }
}
