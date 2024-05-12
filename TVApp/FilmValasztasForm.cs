using TVAppBusinessLogic;

namespace TVApp;

public partial class FilmValasztasForm : Form
{
    public Queries Queries { get; } = new Queries();
    private string nev;

    public FilmValasztasForm(string nev)
    {
        this.nev = nev;
        InitializeComponent();
    }

    private void FilmValasztasForm_Load(object sender, EventArgs e)
    {
        // ha betöltődik a form feltölti a listát
        filmListBox.Items.Clear();
        List<string> TvShows = Queries.ShowAllUniqueTvShow();
        foreach (string film in TvShows)
        {
            filmListBox.Items.Add(film);
        }

    }

    private void filmListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        datumListBox.Items.Clear();
        string selectedfilm = filmListBox.SelectedItem as string;
        List<DateTime> datesforfilm = Queries.GetDateForTvShow(selectedfilm);
        if (selectedfilm != null)
        {
            foreach (DateTime date in datesforfilm)
            {
                datumListBox.Items.Add(date);
            }
        }
    }

    // felvétel: megnéz, hogy van-e másikigaz felvétel, ha igen megnéz dátum (plusz-minusz milyen hosszúak a filmek), ha ez a tartomány egyezik, akkor felvétel-> igen
    private void mentButton_Click(object sender, EventArgs e)
    {
        DateTime date;
        string selectedfilm = filmListBox.SelectedItem as string;
        date = Convert.ToDateTime(datumListBox.SelectedItem);
        string nezo = Queries.WhoIsWathing(selectedfilm, date);
        if (Queries.IsSomeoneWatching(selectedfilm, date))
        {
            if (Queries.AmIWatching(selectedfilm, date, nev))
            {
                MessageBox.Show("Ezt a fimet már te nézed!");
            }
            else
            {
                var result = MessageBox.Show("A filmet már " + nezo + " nézi. Szeretnéd együtt néni vele?", "Közös fimezés", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    AddNewNameAndClose(nev, selectedfilm, date);
                }
                else if (result == DialogResult.No)
                {
                    MessageBox.Show("Válassz másik időpontot, vagy indíts felvételt, ha még nem indított senki!", "Közös filmezés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        else
        {
            if (Queries.CanWeWatch(selectedfilm,date))
            {
                AddNewNameAndClose(nev, selectedfilm, date);
            }
            else
            {
                MessageBox.Show("Ebben az intervallumban már valaki néz egy másik filmet.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void AddNewNameAndClose(string name, string musor, DateTime date)
    {
        Queries.AddNewName(name, musor, date);
        this.Hide();
        this.Close();
    }

    private void FelvetelButton_Click(object sender, EventArgs e)
    {
        DateTime date;
        string selectedfilm = filmListBox.SelectedItem as string;
        date = Convert.ToDateTime(datumListBox.SelectedItem);
        // fgv vane már felvétel
        // ha van masik fgv ido ellenőrzés
        if (Queries.IsThereAnyRecording())
        {
            if(Queries.IsThisOneRecorded(selectedfilm, date))
            {
                MessageBox.Show("Ez a film már fel van véve", "Felvétel",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (Queries.CanWeRecord(selectedfilm,date))
                {
                    Felvetel(selectedfilm, date);
                }
                else
                {
                    MessageBox.Show("Ebben az időpontban már nem lehet több filmet felvenni", "Felvétel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        else
        {
            Felvetel(selectedfilm, date);
        }
    }

    private void Felvetel(string selectedfilm, DateTime date)
    {
        Queries.SetRecording(selectedfilm, date);
        MessageBox.Show("A felvétel beállítva", "Felvétel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        this.Hide();
        this.Close();
    }
}
