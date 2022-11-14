using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerfMon.Business.Models.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfMon.Infrastructure.Configurations
{
    internal class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.HasKey(e => e.Name);

            builder.HasMany(e => e.Measures)
                    .WithOne()
                    .HasForeignKey(e => e.AgentName);

            builder.OwnsOne(e => e.Mqtt);
        }
    }
}
