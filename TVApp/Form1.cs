//using QueriesLib.Queries;
//using TVMusor.Model;

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
            List<Nezo> adatok = Queries.GetAllViewers().ToList();
            dataGridView1.DataSource = adatok;
        }
    }
}
