namespace TVApp.Model
{
    public class Tv
    {
        public int Id { get; set; }
        public string Csatorna { get; set; }
        public string Musor { get; set; }
        public DateTime Kezdet { get; set; }
        public int Hossz {  get; set; }
        public string Mufaj { get; set; }        
        public bool Felvetel {  get; set; }

        public override string ToString()
        {
            return $"{Musor}\n" +
               $"- Channel: {Csatorna}\n" +
               $"- Genre: {Mufaj}\n" +
               $"- Length: {Hossz} minutes\n" +
               $"- Started: {Kezdet}\n" +
               $"- Recording: {(Felvetel ? "Yes" : "No")}";
        }

    }
}
