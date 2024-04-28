namespace TVApp.Model
{
    public class Nezo
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public int TvadasId { get; set; }

        public override string ToString()
        {
            return $"{Nev}";
        }
    }
}
