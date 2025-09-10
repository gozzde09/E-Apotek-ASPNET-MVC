using Microsoft.EntityFrameworkCore;

namespace ProjeApotek.Models
{
    public class MedicinContext : DbContext
    {
        public DbSet<Medicin> Mediciner { get; set; }
        //public DbSet<Doseringar> Doseringar { get; set; }

        public MedicinContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=medicinData.db");
        }
    }
}
