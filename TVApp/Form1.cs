//using QueriesLib.Queries;
//using TVMusor.Model;

using Microsoft.VisualBasic;
using TVApp.Model;
using TVAppBusinessLogic;
using System.Xml.Serialization;

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
            string channel = textBox2.Text;
            string genre = textBox3.Text;
            string tvshow = textBox4.Text;

            if (!string.IsNullOrWhiteSpace(viewerName))
            {
                List<TvShowsWithViewer> adatok = query.SearchForTvshowByName(viewerName).ToList();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = adatok;
            }
            else if ((!string.IsNullOrWhiteSpace(channel)) || (!string.IsNullOrWhiteSpace(genre)) || (!string.IsNullOrWhiteSpace(tvshow)))
            {
                List<Tv> adatok2 = query.SearchForTvShow(channel, genre, tvshow).ToList();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = adatok2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //XmlSerializer serializer = new XmlSerializer(typeof(Tv)); 
    

        }
    }
}
