using MySql.Data.Entity;
using System.Data.Entity;
using WeatherEntities.Model;

namespace WeatherEntities
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class WeatherContext: DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Weather> Weathers { get; set; }
        
        public WeatherContext():base("WeatherContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public static WeatherContext Create()
        {
            return new WeatherContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Weather>()
                        .HasRequired(m => m.City)
                        .WithMany(t => t.Weathers)
                        .HasForeignKey(m => m.Id_City)
                        .WillCascadeOnDelete(true);
        }
    }
}
