using PerfMon.Business.Models.Agent.Exceptions;
using PerfMon.Business.Repositories;
using PerfMon.Business.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfMon.Business.Models.Agent
{
    public class Agent : IAggregateRoot
    {
        private ICollection<Measure> _measures = new List<Measure>();
        public string Name { get; private set; } = string.Empty;
        public DateTime LastSeen { get; private set; }
        public bool Inactive { get; private set; } = false;
        public IEnumerable<Measure> Measures => _measures.AsEnumerable();
        public MqttChannel? Mqtt { get; private set; }

        // for ef
        private Agent() { } 

        public Agent(string name)
        {
            LastSeen = DateTime.Now;
            Name = name;
            _measures = new List<Measure>();
            Mqtt = null;
        }


        public void Ping()
        {
            LastSeen = DateTime.Now;
        }

        /// <summary>
        /// Upsert a given measure. <br/>
        /// It may throw exceptions if the operation is invalid
        /// </summary>
        /// <param name="uniqueName"></param>
        /// <param name="unit"></param>
        /// <param name="type"></param>
        public void RegisterMeasure(string uniqueName, string unit, MeasureType type)
        {
            LastSeen = DateTime.Now;
            var existing = _measures.SingleOrDefault(m => m.UniqueName == uniqueName);
            if (existing != null)
                existing.ChangeConfiguration(unit, type);
            else
            {
                var measure = new Measure(this, uniqueName, type, unit);
                _measures.Add(measure);
            }
        }

        public async Task<bool> RegisterSampleAsync(string uniqueName, DateTime timestamp, double value, ISamplesRepo sampleRepo)
        {
            LastSeen = DateTime.Now;
            var measure = GetMeasure(uniqueName);
            if (measure == null)
                return false;

            // update measure metadata
            measure.RegisterNewValueTimestamp(timestamp);

            await sampleRepo.RegisterSampleAsync(new Sample.Sample(measure, timestamp, value));
            return true;
        }
        
        public void AssignMqttChannel(MqttChannel channel)
        {
            Mqtt = channel;
        }
        public Measure? GetMeasure(string uniqueName)
        {
            return _measures.SingleOrDefault(measure => measure.UniqueName == uniqueName);
        }


    }
}
