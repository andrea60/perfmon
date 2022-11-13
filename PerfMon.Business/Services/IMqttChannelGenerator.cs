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
        MqttChannelInfo GenerateChannel(Agent agent);
    }

    public class MqttChannelInfo
    {
        public string Name { get; private set; }
        public string Password { get; private set; }

        public MqttChannelInfo(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }

    public class MqttChannelGenerator : IMqttChannelGenerator
    {
        public MqttChannelInfo GenerateChannel(Agent agent)
        {
            var pw = GenerateRandomPassword(12);
            return new MqttChannelInfo(agent.Name, pw);
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
