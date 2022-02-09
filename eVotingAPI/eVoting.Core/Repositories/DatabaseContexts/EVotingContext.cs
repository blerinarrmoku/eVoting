using Microsoft.EntityFrameworkCore;

namespace eVoting.Core.Repositories.DatabaseContexts
{
    public class EVotingContext : DbContext
    {
        public EVotingContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public DbSet<Model.Entities.Votes.Vote> Votes { get; set; }
    }
}
