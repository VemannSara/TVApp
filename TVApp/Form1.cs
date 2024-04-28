//using QueriesLib.Queries;
//using TVMusor.Model;

using Microsoft.VisualBasic;
using TVApp.Model;
using TVAppBusinessLogic;
using System.Xml.Serialization;
using System.Diagnostics;

namespace TVApp
{
    public partial class Form1 : Form
    {
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
            List<TvShowsWithViewer> adatok = Queries.GetTvShowsWithViewers();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = adatok;
            //dataGridView1.AutoSize = true; nem lesz vele görgetés
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string viewerName = textBox1.Text;
            string channel = textBox2.Text;
            string genre = textBox3.Text;
            string tvshow = textBox4.Text;

            if (!string.IsNullOrWhiteSpace(viewerName))
            {
                List<TvShowsWithViewer> adatok = Queries.SearchForTvshowByName(viewerName);
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = adatok;
            }
            else if ((!string.IsNullOrWhiteSpace(channel)) || (!string.IsNullOrWhiteSpace(genre)) || (!string.IsNullOrWhiteSpace(tvshow)))
            {
                List<Tv> adatok2 = Queries.SearchForTvShow(channel, genre, tvshow);
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = adatok2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //List<TvShowsWithViewer> tvShowsWithViewersList = Queries.GetTvShowsWithViewers();            
            //string xmlMessage = Serializer<List<TvShowsWithViewer>>.Serialize(tvShowsWithViewersList);
            //Debug.WriteLine(xmlMessage);
            Form dialog = new Form();
            dialog.ShowDialog();
        }
    }
}
