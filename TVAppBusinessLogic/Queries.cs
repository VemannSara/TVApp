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

    public IEnumerable<TvShowsWithViewer> GetAllTvShowByViewer(string inputname)
    {
        using var db = new TvContext();
        var query = from tv in db.Tvadasok
                    join nezo in db.Nezok on tv.Id equals nezo.TvadasId
                    where nezo.Nev == inputname
                    select new TvShowsWithViewer
                    {                      
                        Tvshow = tv,
                        Nezo = nezo,
                        Nev = inputname,
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

  

}
