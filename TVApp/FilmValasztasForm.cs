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

namespace TVApp
{
    public partial class FilmValasztasForm : Form
    {
        public Queries Queries { get; set; } = new Queries();
        public FilmValasztasForm()
        {
            InitializeComponent();
        }

        private void FilmValasztasForm_Load(object sender, EventArgs e)
        {
            // ha betöltődik a form feltölti a listát
            listBox1.Items.Clear();
            List<string> TvShows = Queries.ShowAllUniqueTvShow();
            foreach (string film in TvShows)
            {
                listBox1.Items.Add(film);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string selectedfilm = listBox1.SelectedItem as string;
            List<DateTime> datesforfilm = Queries.GetDateForTvShow(selectedfilm);
            if (selectedfilm != null)
            { 
                foreach (DateTime date in datesforfilm)
                { 
                    listBox2.Items.Add(date);
                }
            }
        }
    }


}
