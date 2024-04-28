using System.ComponentModel;
using TVApp.Model;

namespace TVAppBusinessLogic;

[Serializable]
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
}
