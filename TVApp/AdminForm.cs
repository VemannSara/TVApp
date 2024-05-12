using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using TVApp.Model;
using TVAppBusinessLogic;

namespace TVApp
{
    public partial class AdminForm : Form
    {
        public Queries Queries { get; } = new Queries();
        public ChartHelper ChartHelper { get; } = new ChartHelper();
        public string musor;
        public string mufaj;
        public string csatorna;
        public DateTime datum;
        public int hossz;
        public int Id;

        public AdminForm()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy HH:mm:ss";
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            RefreshData();        
        }

        private void CreateBarSeries()
        {
            var model = new PlotModel { Title = "Tv nézettség" };

            DateTime startTime = dateTimePicker2.Value.Date;
            DateTime endTime = dateTimePicker3.Value.Date;
            Dictionary<DateTime, int> watchingdata = Queries.GetWatchingData(startTime, endTime);

            var barSeries = new BarSeries
            {
                ItemsSource = ChartHelper.CreateBarItems(watchingdata),
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0} perc"
            };
            model.Series.Add(barSeries);

            List<string> days = new List<string>();
            while (startTime <= endTime)
            {
                days.Add(startTime.ToString("yyyy.MM.dd"));
                startTime = startTime.AddDays(1);
            }

            model.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Left,
                ItemsSource = days
            });

            plotView1.Model = model;
        }

        private void CreatePieChartChannel()
        {
            var model = new PlotModel { Title = "Csatornák nézettsége" };

            PieSeries seriesP1 = new PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0
            };
            
            Dictionary<string, double> channeldata = Queries.GetChannelData();
            seriesP1.Slices = ChartHelper.CreatePieSlices(channeldata);       

            model.Series.Add(seriesP1);

            plotView2.Model = model;           
        }

        private void CreatePieChartGenre()
        {
            var model = new PlotModel { Title = "Műfajok szerinti megoszlás" };

            PieSeries seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.8, AngleSpan = 360, StartAngle = 0 };
            Dictionary<string,double> genredata = Queries.GetGenreData();

            seriesP1.Slices = ChartHelper.CreatePieSlices(genredata);

            model.Series.Add(seriesP1);
            plotView3.Model = model;
        }
        public void RefreshData()
        {
            List<Tv> adatok = Queries.GetAllTvShows();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = adatok;
            dataGridView1.ReadOnly = true;
            CreateBarSeries();
            CreatePieChartChannel();
            CreatePieChartGenre();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            musor = MusorTextbox.Text;
            csatorna = CsatornaTextBox.Text;
            mufaj = MufajTextbox.Text;
            datum = dateTimePicker1.Value;
            hossz = (int)numericUpDown2.Value;
            Queries.AddNewShow(musor, csatorna, mufaj, datum,hossz);
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
            Tv tvadasok = new Tv();

            Id = (int)numericUpDown1.Value;
            tvadasok.Musor = MusorTextbox.Text;
            tvadasok.Csatorna = CsatornaTextBox.Text;
            tvadasok.Mufaj = MufajTextbox.Text;
            tvadasok.Kezdet = dateTimePicker1.Value;
            tvadasok.Hossz = (int)numericUpDown2.Value;
            Queries.Update(Id, tvadasok);
            RefreshData();
        }

        private void MutasdButton_Click(object sender, EventArgs e)
        {
            CreateBarSeries();
        }
    }
}
