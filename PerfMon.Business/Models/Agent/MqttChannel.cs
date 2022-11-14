using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfMon.Business.Models.Agent
{
    public record MqttChannel
    {
        public string Channel { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;

        private MqttChannel() { }

        public MqttChannel(string channel, string password)
        {
            Channel = channel;
            Password = password;
        }
    }
}
