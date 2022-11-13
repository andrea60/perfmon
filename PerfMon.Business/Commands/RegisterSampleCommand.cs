using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfMon.Business.Commands
{
    public record RegisterSampleCommand(string agent, string measure, DateTime timestamp, double value) : IRequest<bool>;
}
