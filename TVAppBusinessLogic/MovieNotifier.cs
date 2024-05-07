using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVApp.Model;

namespace TVAppBusinessLogic
{
    public class MovieNotifier
    {
        Queries queries = new Queries();
        public delegate void MovieStartingDelegate(string musor);
        public event MovieStartingDelegate MovieStarting;

        public void Monitor()
        {
            CheckTvShows();
            TimeSpan ido = new TimeSpan(0, 1, 0);
            Task.Delay(ido).ContinueWith(t => Monitor());
        }

        private void CheckTvShows()
        {
            List<Tv> filmek = queries.GetAllTvShows();
            string datum = "yyyy.M.dd.H.m";
            foreach (Tv tv in filmek)
            {
                if (DateTime.Now.AddMinutes(15).ToString(datum) == tv.Kezdet.ToString(datum))
                {
                    // ha null a moviestarting akkor nem hívja meg az invoke-ot 
                    MovieStarting?.Invoke(tv.Musor);
                }
                else
                {
                    Debug.WriteLine($"A {tv.Musor} nem kezdődik 15 perc múlva film");
                }
            }
        }

        //public async Task StartMonitoring()
        //{
        //    DateTime notificationTime = start.AddMinutes(-15);

        //    TimeSpan delay = notificationTime - DateTime.Now;

        //    if (delay.TotalMilliseconds > 0)
        //    {
        //        await Task.Delay(delay);

        //        //ablak mutatása
        //    }
            
        //}
    }
}
