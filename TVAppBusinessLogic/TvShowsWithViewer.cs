using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVApp.Model;

namespace TVAppBusinessLogic;

public class TvShowsWithViewer
{

    public int TvId { get; set; }
    public string Musor { get; set; }
    public string Csatorna { get; set; }
    public string Mufaj { get; set; }
    public int Hossz {  get; set; }
    public DateTime Kezdet { get; set; }
    public bool Felvetel { get; set; }
    [Browsable(false)] // ezt a property-t nem szeretném megjeleníteni
    public Tv Tvshow { get; set; }
    public string Nev {  get; set; }
    [Browsable(false)]
    public Nezo Nezo { get; set; }

    public List<TvShowsWithViewer> ShowsWithViewerslist()
    {
        //var tvShowsWithViewers = new List<TvShowsWithViewer>();
        using var db = new TvContext();
        var tvShowsWithViewers = (from Tvshow in db.Tvadasok
                                  join Nezo in db.Nezok
                                  on Tvshow.Id equals Nezo.TvadasId into joinedData
                                  from Nezo in joinedData.DefaultIfEmpty() // úgy viselkedik minta leftjoin lenne
                                  select new TvShowsWithViewer
                                  {
                                      TvId=Tvshow.Id,
                                      Musor = Tvshow.Musor,
                                      Csatorna = Tvshow.Csatorna,
                                      Mufaj = Tvshow.Mufaj,
                                      Hossz = Tvshow.Hossz,
                                      Kezdet = Tvshow.Kezdet,
                                      Felvetel = Tvshow.Felvetel,
                                      Tvshow = Tvshow ?? new Tv
                                      {
                                          Id = 0,
                                          Musor = "a",
                                          Csatorna = "b",
                                          Mufaj = "b",
                                          Hossz = 123,
                                          Kezdet = DateTime.Now,
                                          Felvetel = false,
                                      },
                                      //TvadasId = Nezo.TvadasId,
                                      Nev = Nezo.Nev,
                                      Nezo = Nezo ?? new Nezo
                                      {
                                          Id = 0,
                                          TvadasId = 0,
                                          Nev = ""
                                      }
                                  }
                                  ).ToList();
                                                        
        return tvShowsWithViewers;
    }

}




