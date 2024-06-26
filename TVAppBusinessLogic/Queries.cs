﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TVApp.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TVAppBusinessLogic;

public class Queries
{
    ChartHelper ChartHelper { get; set; } = new ChartHelper();
    // csak a TVadasok tábla adatait kéri le
    public List<Tv> GetAllTvShows()
    {
        using var db = new TvContext();
        return db.Tvadasok.ToList();
    }

    // csak a nézők tábla adatait kéri le
    public List<Nezo> GetAllViewers()
    {
        using var db = new TvContext();
        return db.Nezok.ToList();
    }

    public List<TvShowsWithViewer> SearchForTvshowByName(string inputname)
    {
        using var db = new TvContext();
        var query = from tv in db.Tvadasok
                    join nezo in db.Nezok on tv.Id equals nezo.TvadasId //Tv adás alapján kötöm össze
                    where nezo.Nev.Contains(inputname)
                    select new TvShowsWithViewer
                    {
                        Tvshow = tv,
                        Nezo = nezo,
                        Nev = nezo.Nev,
                        Musor = tv.Musor,
                        Hossz = tv.Hossz,
                        Kezdet = tv.Kezdet,
                        Csatorna = tv.Csatorna,
                        Felvetel = tv.Felvetel,
                        Mufaj = tv.Mufaj,
                        TvId = tv.Id
                    };
        return query.ToList();
    }

    public List<Tv> SearchForTvShow(string channel, string genre, string tvshow, DateTime date)
    {
        using var db = new TvContext();
        var query = from tv in db.Tvadasok
                    where (string.IsNullOrEmpty(channel) || tv.Csatorna.Contains(channel))
                    && (string.IsNullOrEmpty(genre) || tv.Mufaj.Contains(genre))
                    && (string.IsNullOrEmpty(tvshow) || tv.Musor.Contains(tvshow))
                    && (date.Date == new DateTime(1990,1,1) || tv.Kezdet.Date == date.Date)
                    //&& (tv.Musor.Contains(date))
                    select new Tv
                    {
                        Musor = tv.Musor,
                        Hossz = tv.Hossz,
                        Kezdet = tv.Kezdet,
                        Csatorna = tv.Csatorna,
                        Felvetel = tv.Felvetel,
                        Mufaj = tv.Mufaj,
                        Id = tv.Id
                    };
        return query.ToList();
    }

    public List<TvShowsWithViewer> GetTvShowsWithViewers()
    {
        using var db = new TvContext();
        var tvShowsWithViewers = (from Tvshow in db.Tvadasok
                                  join Nezo in db.Nezok
                                  on Tvshow.Id equals Nezo.TvadasId into joinedData
                                  from Nezo in joinedData.DefaultIfEmpty() // úgy viselkedik minta leftjoin lenne
                                  select new TvShowsWithViewer
                                  {
                                      TvId = Tvshow.Id,
                                      Musor = Tvshow.Musor,
                                      Csatorna = Tvshow.Csatorna,
                                      Mufaj = Tvshow.Mufaj,
                                      Hossz = Tvshow.Hossz,
                                      Kezdet = Tvshow.Kezdet,
                                      Felvetel = Tvshow.Felvetel,
                                      Nev = Nezo.Nev,
                                  }
                                  ).ToList();

        //tv id alapján egyediek
        List<TvShowsWithViewer> tvShowsWithViewersDistincted = tvShowsWithViewers.DistinctBy(item => item.TvId).ToList();

        foreach (TvShowsWithViewer tvShowsWithViewer in tvShowsWithViewersDistincted)
        {
            string ujNev = string.Empty;           
            tvShowsWithViewers.Where(item => item.TvId == tvShowsWithViewer.TvId).ToList().ForEach(item => ujNev += $"{item.Nev},");
            // utolsó vessző kitörlése
            ujNev = ujNev.Remove(ujNev.Length - 1, 1);
            tvShowsWithViewer.Nev = ujNev;
        }

        return tvShowsWithViewersDistincted;
    }

    public List<TvShowsWithViewer> FilterDate(DateTime date, List<TvShowsWithViewer> tvShowsWithViewersList)
    {
        var query = tvShowsWithViewersList.Where(tv => tv.Kezdet.Date == date.Date).ToList();
        return query;
    }

    public List<string> ShowAllUniqueTvShow()
    {
        List<TvShowsWithViewer> adatok = GetTvShowsWithViewers();
        using var db = new TvContext();
        var uniqueTvShow = adatok.Select(tv => tv.Musor).Distinct().ToList();
        return uniqueTvShow;
    }

    public List<DateTime> GetDateForTvShow(string film)
    {
        List<TvShowsWithViewer> adatok = GetTvShowsWithViewers();
        using var db = new TvContext();
        var dates = adatok.Where(tv => tv.Musor == film).Select(tv => tv.Kezdet).ToList();
        return dates;
    }

    public void AddNewName(string name, string musor, DateTime date)
    {
        using var db = new TvContext();
        var tvShow = db.Tvadasok.FirstOrDefault(tv => tv.Musor == musor && tv.Kezdet == date);
        if (tvShow != null)
        {
            var newViewer = new Nezo
            {
                Nev = name,
                TvadasId = tvShow.Id
            };
            db.Nezok.Add(newViewer);
            db.SaveChanges();
        }
    }

    public bool IsSomeoneWatching(string musor, DateTime date)
    {
        using var db = new TvContext();
        List<TvShowsWithViewer> adatok = GetTvShowsWithViewers();
        var nev = adatok.Where(tv => tv.Musor == musor && tv.Kezdet == date).Select(tv => tv.Nev).FirstOrDefault();
        if (string.IsNullOrWhiteSpace(nev))
        {
            return false;
        }
        else
        {
            return true;
        }

    }
    public bool AmIWatching(string musor, DateTime date, string actualname)
    {

        using var db = new TvContext();
        List<TvShowsWithViewer> adatok = GetTvShowsWithViewers();
        var nev = adatok.Where(tv => tv.Musor == musor && tv.Kezdet == date).Select(tv => tv.Nev).FirstOrDefault();
        if (!nev.Contains(actualname))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public string WhoIsWathing(string musor, DateTime date)
    {
        using var db = new TvContext();
        List<TvShowsWithViewer> adatok = GetTvShowsWithViewers();
        var nev = adatok.Where(tv => tv.Musor == musor && tv.Kezdet == date).Select(tv => tv.Nev).FirstOrDefault();
        return nev; // esetleg exeption ha nem nézi senki
    }

    // update tvshowwithviewer
    public List<TvShowsWithViewer> WatchingTogether(string name, string musor, DateTime date)
    {
        using var db = new TvContext();
        List<TvShowsWithViewer> adatok = GetTvShowsWithViewers();
        var update = adatok.Where(tv => tv.Musor == musor && tv.Kezdet == date);
        return update.ToList();
    }

    public void SetRecording(string musor, DateTime date)
    {
        using var db = new TvContext();
        db.Tvadasok.Where(tv => tv.Musor == musor && tv.Kezdet == date).FirstOrDefault().Felvetel = true;
        db.SaveChanges();
    }

    public bool IsThereAnyRecording()
    {
        using var db = new TvContext();
        var query = db.Tvadasok.Where(tv => tv.Felvetel == true).ToList();
        return query != null;
    }

    public bool IsThisOneRecorded(string musor, DateTime date)
    {
        using var db = new TvContext();
        var query = db.Tvadasok.Where(tv => tv.Musor == musor && tv.Kezdet == date && tv.Felvetel == true).FirstOrDefault();
        return query != null;
    }

    public bool CanWeRecord(string musor, DateTime date)
    {
        using var db = new TvContext();
        var felvetelek = db.Tvadasok.Where(tv => tv.Felvetel == true).ToList();
        var hossz = db.Tvadasok.Where(tv => tv.Musor == musor && tv.Kezdet == date).Select(tv => tv.Hossz).FirstOrDefault();

        foreach (var film in felvetelek)
        {
            DateTime endtimeRec = film.Kezdet.AddMinutes(film.Hossz);
            DateTime endtimeSelect = date.AddMinutes(hossz);
            if (date.Date == film.Kezdet.Date)
            {
                if (date < film.Kezdet && endtimeSelect > film.Kezdet)
                {
                    return false;
                }
                if (date > film.Kezdet && date < endtimeRec)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public bool CanWeWatch(string musor, DateTime date)
    {
        using var db = new TvContext();
        var nezettMusorok = GetTvShowsWithViewers().Where(nezo => !string.IsNullOrWhiteSpace(nezo.Nev));
        var hossz = db.Tvadasok.Where(tv => tv.Musor == musor && tv.Kezdet == date).Select(tv => tv.Hossz).FirstOrDefault();

        foreach (var film in nezettMusorok)
        {
            DateTime endtimeWatched = film.Kezdet.AddMinutes(film.Hossz);
            DateTime endtimeSelect = date.AddMinutes(hossz);
            if (date.Date == film.Kezdet.Date)
            {
                if (date < film.Kezdet && endtimeSelect > film.Kezdet)
                {
                    return false;
                }
                if (date > film.Kezdet && date < endtimeWatched)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void AddNewShow(string musor, string csatorna, string mufaj, DateTime idopont, int hossz)
    {
        using var db = new TvContext();
        Tv newShow = new Tv
        {
            Musor = musor,
            Csatorna = csatorna,
            Mufaj = mufaj,
            Kezdet = idopont,
            Hossz = hossz
        };
        db.Tvadasok.Add(newShow);
        db.SaveChanges();
    }

    public void DeleteTvShows(int id)
    {
        using var db = new TvContext();
        var torles = db.Tvadasok.Where(tv => tv.Id == id).FirstOrDefault();
        if (torles != null)
        {
            db.Tvadasok.Remove(torles);
            db.SaveChanges();
        }
        // doto exeption
    }

    public void Update(int id, Tv tvadas)
    {
        using var db = new TvContext();
        var update = db.Tvadasok.Where(tv => tv.Id == id).FirstOrDefault();
        if (update != null)
        {
            update.Musor = !string.IsNullOrWhiteSpace(tvadas.Musor) ? tvadas.Musor : update.Musor;
            update.Mufaj = !string.IsNullOrWhiteSpace(tvadas.Mufaj) ? tvadas.Mufaj : update.Mufaj;
            update.Csatorna = !string.IsNullOrWhiteSpace(tvadas.Csatorna) ? tvadas.Csatorna : update.Csatorna;
            update.Kezdet = tvadas.Kezdet;
            update.Hossz = tvadas.Hossz != 0 ? tvadas.Hossz : update.Hossz;

            db.SaveChanges();
        }
        //todo exeption
    }

    public Dictionary<DateTime,int> GetWatchingData(DateTime kezdet, DateTime veg)
    {
        using var db = new TvContext();
        List<TvShowsWithViewer> adatok = GetTvShowsWithViewers();

        Dictionary<DateTime, int> dict = ChartHelper.CreateDictionary(kezdet, veg);

        var query = adatok.Where(tv => tv.Kezdet.Date >= kezdet.Date && tv.Kezdet.Date <= veg.Date).ToList();
        foreach (var adat in query)
        {
            if (!string.IsNullOrWhiteSpace(adat.Nev)) // tehát nézi valaki a filmet
            {
                dict[adat.Kezdet.Date] += adat.Hossz; // megkeresi az adott kulcsú elemet és az értéket módosítja
                //dict.Add(adat.Kezdet, adat.Hossz);
            }
        }
        return dict;
    }

    public Dictionary<string,double> GetChannelData()
    {
        using var db = new TvContext();
        List<TvShowsWithViewer> adatok = GetTvShowsWithViewers();
        Dictionary<string, double> dict = new Dictionary<string, double>();

        var uniquechannels = adatok.Select(tv => tv.Csatorna).Distinct().ToList();

        foreach (var channel in uniquechannels)
        {
            dict[channel] = 0;
        }

        foreach (var adat in adatok)
        {
            if (!string.IsNullOrWhiteSpace(adat.Nev))
            {
                if (dict.ContainsKey(adat.Csatorna))
                {
                    dict[adat.Csatorna] += 1; 
                }
                
            }
        }
        return dict;
    }

    public Dictionary<string, double> GetGenreData()
    {
        using var db = new TvContext();
        List<TvShowsWithViewer> adatok = GetTvShowsWithViewers();
        Dictionary<string, double> dict = new Dictionary<string, double>();

        var uniquegenres = adatok.Select(tv => tv.Mufaj).Distinct().ToList();

        foreach (var genre in uniquegenres)
        {
            dict[genre] = 0;
        }

        foreach (var adat in adatok)
        {
            if (dict.ContainsKey(adat.Mufaj))
            {
                dict[adat.Mufaj] += 1;
            }
        }
        return dict;
    }

}
