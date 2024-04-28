using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVApp.Model;
using TVAppBusinessLogic;
using System.Xml.Serialization;
using System.Diagnostics;

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
            List<TvShowsWithViewer> tvShowWithCorrectDate = Queries.FilterDate(valasztott, tvShowsWithViewersList); //tvShowsWithViewersList.Where(tv => tv.Kezdet.Date == valasztott).ToList(); // Megnézem, hogy a kiválasztott dátum stimmel-e
            string xmlMessage = Serializer<List<TvShowsWithViewer>>.Serialize(tvShowWithCorrectDate);
            string filepath = "C:\\xml\\File.xml";
            File.WriteAllText(filepath, xmlMessage);
            MessageBox.Show("Az XML el lett mentve a: " + filepath + " helyre", "XML mentés", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Debug.WriteLine(xmlMessage);
        }
    }
}
