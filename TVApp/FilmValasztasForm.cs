using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVApp.Model;
using TVAppBusinessLogic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TVApp;

public partial class FilmValasztasForm : Form
{
    public Queries Queries { get; set; } = new Queries();
    NevBekeres nevBekeres = new NevBekeres();
    private string nev;

    public FilmValasztasForm(string nev)
    {
        this.nev = nev;
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
    //TODO felvétel gomb
    // felvétel: megnéz, hogy van-e másikigaz felvétel, ha igen megnéz dátum (plusz-minusz milyen hosszúak a filmek), ha ez a tartomány egyezik, akkor felvétel-> igen
    private void button1_Click(object sender, EventArgs e)
    {
        
        
        // ha nem másik időpont felajánlás--> újra kilistázza az időpontokat azon kívűl amit már kilistázott
        
        DateTime date;
        string selectedfilm = listBox1.SelectedItem as string;
        date = Convert.ToDateTime(listBox2.SelectedItem);
        string nezo = Queries.WhoIsWathing(selectedfilm, date);
        if (Queries.IsSomeoneWatching(selectedfilm,date))
        {
            if (Queries.AmIWatching(selectedfilm, date, nev))
            {
                MessageBox.Show("Ezt a fimet már te nézed!");
            }
            else
            {
                var result = MessageBox.Show("A filmet már " + nezo + " nézi. Szeretnéd együtt néni vele?","Közös fimezés", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Queries.AddNewName(nev, selectedfilm, date);
                    this.Hide();
                    this.Close();
                }
                else if (result == DialogResult.No)
                {
                    MessageBox.Show("Válassz másik időpontot, vagy indíts felvételt, ha még nem indított senki!");
                }
            }
        }
        else
        {
            Queries.AddNewName(nev, selectedfilm, date);
            this.Hide();
            this.Close();
        }
    }
    private void AddNewNameAndClose(string name, string musor, DateTime date)
    {
        Queries.AddNewName(nev, musor, date);
        this.Hide();
        this.Close();
    }

}
