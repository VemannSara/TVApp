namespace TVApp
{
    public partial class NevBekeres : Form
    {
        private KezdolapForm kezdolapform = new KezdolapForm();
        private string Nev => textBox1.Text;      
       
        public NevBekeres()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kezdolapform.Label8.Text = "Szia " + Nev + " !";
            kezdolapform.Nev = Nev;
            this.Hide();
            kezdolapform.ShowDialog();
            this.Close();
        }
    }
}
