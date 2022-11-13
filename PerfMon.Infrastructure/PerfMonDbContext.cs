using Microsoft.EntityFrameworkCore;
using PerfMon.Business.Models.Agent;
using PerfMon.Business.Models.Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfMon.Infrastructure
{
    internal class PerfMonDbContext : DbContext
    {
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Sample> Samples { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PerfMonDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // run from CLI (dotnet migrations)
                optionsBuilder.UseSqlite("Data Source=v1.db");
            }
        }
    }
}
