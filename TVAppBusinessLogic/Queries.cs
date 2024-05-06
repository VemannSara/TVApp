﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TVApp.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TVAppBusinessLogic;

public class Queries
{
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

    public List<Tv> SearchForTvShow(string channel, string genre, string tvshow)
    {
        using var db = new TvContext();
        var query = from tv in db.Tvadasok
                    where (string.IsNullOrEmpty(channel) || tv.Csatorna.Contains(channel))
                    && (string.IsNullOrEmpty(genre) || tv.Mufaj.Contains(genre))
                    && (string.IsNullOrEmpty(tvshow) || tv.Musor.Contains(tvshow))
                    select new Tv
                    {
                        Musor = tv.Musor,
                        Hossz = tv.Hossz,
                        Kezdet = tv.Kezdet,
                        Csatorna = tv.Csatorna,
                        Felvetel = tv.Felvetel,
                        Mufaj = tv.Mufaj,
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

        List<TvShowsWithViewer> tvShowsWithViewersDistincted = tvShowsWithViewers.DistinctBy(item => item.TvId).ToList();

        foreach (TvShowsWithViewer tvShowsWithViewer in tvShowsWithViewersDistincted)
        {
            string ujNev = string.Empty;
            tvShowsWithViewers.Where(item => item.TvId == tvShowsWithViewer.TvId).ToList().ForEach(item => ujNev += $"{item.Nev},");
            ujNev = ujNev.Remove(ujNev.Length - 1, 1);
            tvShowsWithViewer.Nev = ujNev;
        }

        return tvShowsWithViewersDistincted;
    }

    public List<TvShowsWithViewer> FilterDate(DateTime date, List<TvShowsWithViewer> tvShowsWithViewersList)
    {
        using var db = new TvContext();
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
        return nev; // esetleg exeprion ha nem nézi senki
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
            if ((date.Date == film.Kezdet.Date) && (endtimeRec >= date || endtimeSelect >= date))
            {
                return false;
            }
        }
        return true;
    }
}
