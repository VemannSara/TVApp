using TVApp.Model;

namespace TVAppBusinessLogic;

public class Queries
{
    // csak a TVadasok tábla adatait kéri le
    public IEnumerable<Tv> GetAllTvShows()
    {
        using var db = new TvContext();
        return db.Tvadasok.ToList();
    }

    // csak a nézők tábla adatait kéri le
    public IEnumerable<Nezo> GetAllViewers()
    {
        using var db = new TvContext();
        return db.Nezok.ToList();
    }

    public IEnumerable<TvShowsWithViewer> SearchForTvshowByName(string inputname)
    {
        using var db = new TvContext();
        var query = from tv in db.Tvadasok
                    join nezo in db.Nezok on tv.Id equals nezo.TvadasId //Tv adás alapján kötöm össze szaaar
                    where nezo.Nev.Contains(inputname)
                       //&& (string.IsNullOrEmpty(genre) || tv.Mufaj.Contains(genre))
                       //&& (string.IsNullOrEmpty(channel) || tv.Csatorna.Contains(channel))
                       //&& (string.IsNullOrEmpty(tvshow) || tv.Musor.Contains(tvshow))
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

    public IEnumerable<Tv> SearchForTvShow(string channel, string genre, string tvshow)
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

  

}
