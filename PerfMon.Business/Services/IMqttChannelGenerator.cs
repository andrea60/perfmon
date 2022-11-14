using PerfMon.Business.Models.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfMon.Business.Services
{
    public interface IMqttChannelGenerator
    {
        MqttChannel GenerateChannel(Agent agent);
    }

   
    public class MqttChannelGenerator : IMqttChannelGenerator
    {
        public MqttChannel GenerateChannel(Agent agent)
        {
            var pw = GenerateRandomPassword(12);
            return new MqttChannel(agent.Name, pw);
        }
        private string GenerateRandomPassword(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    
    }
}
