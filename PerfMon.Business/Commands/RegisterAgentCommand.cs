using MediatR;
using PerfMon.Business.Models.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfMon.Business.Commands
{
    public record RegisterAgentCommand(string name, IEnumerable<AgentMeasure> measures) : IRequest<AgentRegistrationResult>;


    public record AgentMeasure(string name, string unit, MeasureType type);


    public record AgentRegistrationResult(string mqttChannel);
}
