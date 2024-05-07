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
        
        public Label Label8 => label8;
        public DataGridView DataGridView1 => dataGridView1;
        public Queries Queries { get; set; } = new Queries();
        public string Nev { get; set; }

        public Form1()
        {
            InitializeComponent();
            MovieNotifier idozito = new MovieNotifier();
            idozito.MovieStarting += (musor) => MessageBox.Show($"A {musor} 15 perc múlva kezdõdik.", "Film kezdés", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // külön task-ban elindítja a monitorozást
            Task.Factory.StartNew(() => idozito.Monitor());
        }

        private void Form1_Load(object sender, EventArgs e)
        {          
            RefreshData();
        }

        public void RefreshData()
        {
            List<TvShowsWithViewer> adatok = Queries.GetTvShowsWithViewers();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = adatok;
            dataGridView1.ReadOnly = true;
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

            XMLForm dialog = new XMLForm();
            dialog.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FilmValasztasForm dialog = new FilmValasztasForm(Nev);
            dialog.FormClosed += (sender, e) => RefreshData();
            dialog.ShowDialog();
        }
    }
}
