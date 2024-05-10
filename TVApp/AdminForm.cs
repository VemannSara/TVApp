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
    public partial class AdminForm : Form
    {
        public Queries Queries { get; set; } = new Queries();
        public string musor;
        public string mufaj;
        public string csatorna;
        public DateTime datum;
        public int Id;
        public AdminForm()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";
        }


        private void AdminForm_Load(object sender, EventArgs e)
        {
            RefreshData();
        }
        public void RefreshData()
        {
            List<Tv> adatok = Queries.GetAllTvShows();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = adatok;
            dataGridView1.ReadOnly = true;
            //dataGridView1.AutoSize = true; nem lesz vele görgetés
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            musor = MusorTextbox.Text;
            csatorna = CsatornaTextBox.Text;
            mufaj = MufajTextbox.Text;
            datum = dateTimePicker1.Value;
            Queries.AddNewShow(musor,csatorna,mufaj,datum);
            RefreshData();
            //todo exeptions
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Id = (int)numericUpDown1.Value;
            Queries.DeleteTvShows(Id);
            RefreshData();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Tv tvadasok= new Tv();

            Id = (int)numericUpDown1.Value;
            tvadasok.Musor = MusorTextbox.Text;
            tvadasok.Csatorna = CsatornaTextBox.Text;
            tvadasok.Mufaj = MufajTextbox.Text;
            tvadasok.Kezdet = dateTimePicker1.Value;
            Queries.Update(Id, tvadasok);
            RefreshData();
        }
    }
}
