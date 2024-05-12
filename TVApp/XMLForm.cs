using TVAppBusinessLogic;

namespace TVApp
{
    public partial class XMLForm : Form
    {
        public Queries Queries { get; set; } = new Queries();
        public XMLForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime valasztott = dateTimePicker1.Value.Date;
            List<TvShowsWithViewer> tvShowsWithViewersList = Queries.GetTvShowsWithViewers();
            List<TvShowsWithViewer> tvShowWithCorrectDate = Queries.FilterDate(valasztott, tvShowsWithViewersList);
            string xmlMessage = Serializer<List<TvShowsWithViewer>>.Serialize(tvShowWithCorrectDate);
            string filepath = $"C:\\xml\\Musorlista_{valasztott.ToString("yyyy.MM.dd")}.xml";
            File.WriteAllText(filepath, xmlMessage);
            MessageBox.Show("Az XML el lett mentve a: " + filepath + " helyre", "XML mentés", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
