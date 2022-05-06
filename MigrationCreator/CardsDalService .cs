using Cards.Dal.Contracts;
using Cards.Models;
using Microsoft.EntityFrameworkCore;

namespace MigrationCreator
{
    public class CardsDalService : DbContext
    {
        public DbSet<Card> Cards { get; set; }

        private readonly string _connectionString = "server=PETER-PC\\SQLEXPRESS;database=CardsDb;Trusted_Connection=true";
        //public CardsDalService(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(_connectionString, x => x.MigrationsAssembly("Cards.Dal.Ef.Implememtation"));
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
