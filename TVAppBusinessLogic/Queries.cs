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

    // lekéri a nézők és a tv tábla adatait összekötve a tvadasok id-ja alapján
    public  IEnumerable<(Tv tvadas, Nezo nezo)> GetTvShowsWithViewers()
    {
        using var db = new TvContext();

        var tvAdasok = db.Tvadasok.ToList();
        var nezok = db.Nezok.ToList();

        var tvShowsWithViewers = tvAdasok.Select(tv => (tv, nezok.FirstOrDefault(n => n.Tvadas.Id == tv.Id)));

        return tvShowsWithViewers;
    }

}
