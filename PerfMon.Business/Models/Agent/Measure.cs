using PerfMon.Business.Models.Agent.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfMon.Business.Models.Agent
{
    public class Measure
    {
        public string AgentName { get; private set; } = string.Empty;
        public string UniqueName { get; private set; } = string.Empty;
        public MeasureType MeasureType { get; private set; }
        public string Unit { get; private set; } = string.Empty;
        public DateTime? FirstValueTimestamp { get; private set; }
        public DateTime? LastValueTimestamp { get; private set; }

        // for ef
        private Measure() { }
        public Measure(Agent owner, string uniqueName, MeasureType type, string unit)
        {
            UniqueName = uniqueName;
            AgentName = owner.Name;
            MeasureType = type;
            Unit = unit;
        }

        public void ChangeConfiguration(string unit, MeasureType type)
        {
            if (type != MeasureType)
                throw new IncompatibleMeasureException(nameof(Measure.MeasureType));
            Unit = unit;
        }

        public void RegisterNewValueTimestamp(DateTime timestamp)
        {
            if (FirstValueTimestamp == null || timestamp < FirstValueTimestamp)
                FirstValueTimestamp = timestamp;
            if (LastValueTimestamp == null || timestamp > LastValueTimestamp)
                LastValueTimestamp = timestamp;
        }
    }

    public enum MeasureType
    {
        Numeric,
        String
    }
}
