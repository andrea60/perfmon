using PerfMon.Business.Models.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfMon.Business.Models.Sample
{
    public class Sample : IAggregateRoot
    {
        public string MeasureName { get; private set; }
        public string AgentName { get; set; }
        public DateTime Timestamp { get; private set; }
        public double Value { get; private set; }

        // for ef
        private Sample() { }

        public Sample(Measure measure, DateTime timestamp, double value)
        {
            MeasureName = measure.UniqueName;
            AgentName = measure.AgentName;
            Timestamp = timestamp;
            Value = value;  
        }


        
    }
}
