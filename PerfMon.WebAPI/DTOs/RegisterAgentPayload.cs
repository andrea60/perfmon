using PerfMon.Business.Models.Agent;

namespace PerfMon.WebAPI.DTOs
{
    public class RegisterAgentPayload
    {
        /// <summary>
        /// Agent's name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Currently monitored measures
        /// </summary>
        public ICollection<RegisterAgentMeasure> Measures { get; set; } = new List<RegisterAgentMeasure>();
    }


    public class RegisterAgentMeasure
    {
        /// <summary>
        /// Measure unique name
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Measure unit of measurement
        /// </summary>
        public string Unit { get; set; } = string.Empty;
        public MeasureType Type { get; set; }

    }
}
