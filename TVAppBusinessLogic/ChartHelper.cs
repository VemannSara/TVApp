using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVAppBusinessLogic
{
    public class ChartHelper
    {
        public List<BarItem> CreateBarItems(Dictionary<DateTime,int> dict)
        {
            List<BarItem> barItems = new List<BarItem>();
            foreach (int perc in dict.Values)
            {
                barItems.Add(new BarItem() { Value = perc });
            }
            return barItems;
        }

        public Dictionary<DateTime,int> CreateDictionary(DateTime kezdet, DateTime veg)
        {
            Dictionary<DateTime, int> dict = new Dictionary<DateTime, int>();
            while (kezdet.Date <= veg.Date)
            {
                dict.Add(kezdet.Date,0);
                kezdet = kezdet.AddDays(1);
            }
            return dict;
        }

        public List<PieSlice> CreatePieSlices(Dictionary<string,double> dict)
        {
            List<PieSlice> pieSlices = new List<PieSlice>();
            foreach (var item in dict)
            {
                pieSlices.Add(new PieSlice(item.Key,item.Value) { IsExploded=true});
            }
            return pieSlices;

        }
    }
}
