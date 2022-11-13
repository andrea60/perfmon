using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerfMon.Business.Models.Agent;
using PerfMon.Business.Models.Sample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfMon.Infrastructure.Configurations
{
    internal class SampleConfiguration : IEntityTypeConfiguration<Sample>
    {
        public void Configure(EntityTypeBuilder<Sample> builder)
        {
            builder.HasKey(e => new { e.AgentName, e.MeasureName, e.Timestamp });

            builder.HasOne<Measure>()
                    .WithMany()
                    .HasForeignKey(e => new { e.AgentName, e.MeasureName });
        }
    }
}
