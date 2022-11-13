using MediatR;
using PerfMon.Business.Commands;
using PerfMon.Business.Events;
using PerfMon.Business.Models.Agent;
using PerfMon.Business.Repositories;
using PerfMon.Business.Services;

namespace PerfMon.Business.Handlers
{
    internal class RegisterAgentHandler : IRequestHandler<RegisterAgentCommand, AgentRegistrationResult>
    {
        private readonly IAgentRepo agentRepo;
        private readonly IPublisher publisher;
        private readonly IMqttChannelGenerator mqttChannelGenerator;

        public RegisterAgentHandler(IAgentRepo agentRepo, IPublisher publisher, IMqttChannelGenerator mqttChannelGenerator)
        {
            this.agentRepo = agentRepo;
            this.publisher = publisher;
            this.mqttChannelGenerator = mqttChannelGenerator;
        }

        public async Task<AgentRegistrationResult> Handle(RegisterAgentCommand request, CancellationToken cancellationToken)
        {
            var agent = await agentRepo.GetOne(request.name);
            if (agent == null)
            {
                agent = new Agent(request.name);
                await agentRepo.AddAsync(agent);
            }
            else
                agent.Ping();

            if (request.measures.Any())
            {
                foreach (var measure in request.measures)
                    agent.RegisterMeasure(measure.name, measure.unit, measure.type);
            }

            // generate the channel
            agent.AssignMqttChannel(mqttChannelGenerator.GenerateChannel(agent));

            // emit event
            await publisher.Publish(new AgentRegisteredEvent());

            return new AgentRegistrationResult(agent.MqttChannel);
        }
    }
}
