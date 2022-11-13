using MediatR;
using PerfMon.Business.Commands;
using PerfMon.Business.Events;
using PerfMon.Business.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfMon.Business.Handlers
{
    public class RegisterSampleHandler : IRequestHandler<RegisterSampleCommand, bool>
    {
        private IAgentRepo agentRepo;
        private ISamplesRepo samplesRepo;

        private IPublisher publisher;

        public RegisterSampleHandler(IAgentRepo agentRepo, ISamplesRepo samplesRepo, IPublisher publisher)
        {
            this.agentRepo = agentRepo;
            this.samplesRepo = samplesRepo;
            this.publisher = publisher;
        }

        public async Task<bool> Handle(RegisterSampleCommand request, CancellationToken cancellationToken)
        {
            var agent = await agentRepo.GetOne(request.agent);
            if (agent == null)
                return false;

            var result = await agent.RegisterSampleAsync(request.measure, request.timestamp, request.value, samplesRepo);

            if (!result)
                return false;

            await publisher.Publish(new SampleRegisteredEvent());

            return true;
        }
    }
}
