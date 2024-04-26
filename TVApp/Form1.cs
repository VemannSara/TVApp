//using QueriesLib.Queries;
//using TVMusor.Model;

using Microsoft.VisualBasic;
using TVApp.Model;
using TVAppBusinessLogic;

namespace TVApp
{
    public partial class Form1 : Form
    {
        //public Tv tv {  get; set; }
        public Queries Queries { get; set; } = new Queries();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            TvShowsWithViewer tvShowsWithViewer = new TvShowsWithViewer();
            List<TvShowsWithViewer> adatok = tvShowsWithViewer.ShowsWithViewerslist();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = adatok;
            //dataGridView1.AutoSize = true; nem lesz vele görgetés

        }

        private void button3_Click(object sender, EventArgs e)
        {


            Queries query = new Queries();
            string viewerName = textBox1.Text;
            if (textBox1.Text != null)
            {
                //TvShowsWithViewer tvShowsWithViewer = new TvShowsWithViewer();
                //tvShowsWithViewer.Nev = textBox1.Text;
                List<TvShowsWithViewer> adatok = query.GetAllTvShowByViewer(viewerName).ToList();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = adatok;
            }
            else
            {
                MessageBox.Show("írj be egy nevet!");
            }
        }
    }
}
