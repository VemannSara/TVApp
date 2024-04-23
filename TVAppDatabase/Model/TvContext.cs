using Microsoft.EntityFrameworkCore;


namespace TVApp.Model
{
    public class TvContext : DbContext
    {
        //létrehoz egy Dbset-et
        public DbSet<Tv> Tvadasok
        {
            get
            {
                return Set<Tv>();
            }
        }
        public DbSet<Nezo> Nezok
        {
            get 
            {                
                return Set<Nezo>(); 
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = C:\\Users\\Sári\\OneDrive - elte.hu\\60 kredit informatika\\2_felev\\C#\\TVApp\\TVAppDatabase\\Tv.db");
        }
    }
}
