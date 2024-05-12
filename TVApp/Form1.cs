using TVApp.Model;
using TVAppBusinessLogic;

namespace TVApp
{
    public partial class Form1 : Form
    {
        public Label Label8 => label8;
        public Queries Queries { get; } = new Queries();
        public string Nev { get; set; }

        public Form1()
        {
            InitializeComponent();
            MovieNotifier idozito = new MovieNotifier();
            idozito.MovieStarting += (musor) => Notification(musor);
            // külön task-ban elindítja a monitorozást
            Task.Factory.StartNew(() => idozito.Monitor());
        }

        public void Notification(string musor)
        {
            notifyIcon1.BalloonTipText = $"A(z) {musor} 15 perc múlva kezdõdik";
            notifyIcon1.BalloonTipTitle = "Figyelem";
            notifyIcon1.Icon = SystemIcons.Information;
            notifyIcon1.ShowBalloonTip(500);
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
        }

        private void KeresesButton_Click(object sender, EventArgs e)
        {
            string viewerName = textBox1.Text;
            string channel = textBox2.Text;
            string genre = textBox3.Text;
            string tvshow = textBox4.Text;
            DateTime date = dateTimePicker1.Value.Date;

            if (!string.IsNullOrWhiteSpace(viewerName))
            {
                List<TvShowsWithViewer> adatok = Queries.SearchForTvshowByName(viewerName);
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = adatok;
            }
            else if ((!string.IsNullOrWhiteSpace(channel)) || (!string.IsNullOrWhiteSpace(genre)) || (!string.IsNullOrWhiteSpace(tvshow)) || (date != new DateTime(1990, 1, 1)))
            {
                List<Tv> adatok2 = Queries.SearchForTvShow(channel, genre, tvshow, date);
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = adatok2;
            }
        }

        private void XmlButton_Click(object sender, EventArgs e)
        {

            XMLForm dialog = new XMLForm();
            dialog.ShowDialog();
        }

        private void FilmnezesButton_Click(object sender, EventArgs e)
        {
            FilmValasztasForm dialog = new FilmValasztasForm(Nev);
            dialog.FormClosed += (sender, e) => RefreshData();
            dialog.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            AdminForm adminForm = new AdminForm();
            PasswordForm passwordform = new PasswordForm(adminForm);
            adminForm.FormClosed += (sender, e) => RefreshData();
            passwordform.ShowDialog();
        }

        private void ResetDateButton_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = new DateTime(1990, 1, 1);
        }

        private void WholeListButton_Click(object sender, EventArgs e)
        {
            RefreshData();
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            dateTimePicker1.Value = new DateTime(1990, 1, 1);
        }
    }
}
