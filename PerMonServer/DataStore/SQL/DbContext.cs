using Microsoft.EntityFrameworkCore;
using PerMonServer.Models;

namespace PerMonServer.DataStore.SQL
{
    public class PerfMonDbContext : DbContext
    {
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Measure> Measures { get; set; }

        public PerfMonDbContext(DbContextOptions<PerfMonDbContext> options): base(options)
        {

        }
    }
}
