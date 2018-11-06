using Microsoft.EntityFrameworkCore;
using Web.App.Test.Models;

namespace Web.App.Test.Repository.SQL
{
    public class PlayerContext : DbContext
    {
        public PlayerContext()
        {
        }

        public PlayerContext(DbContextOptions<PlayerContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=Player;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public DbSet<PlayerModel> Player { get; set; }
    }
}
