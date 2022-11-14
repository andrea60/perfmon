using MediatR;
using Microsoft.AspNetCore.Mvc;
using PerfMon.Business.Commands;
using PerfMon.WebAPI.DTOs;

namespace PerfMon.WebAPI.Controllers
{
    [ApiController]
    [Route("v1/agent")]
    public class AgentController : Controller
    {
        private readonly IMediator _mediator;

        public AgentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Registers an agent and returns its mqtt information
        /// </summary>
        /// <param name="payload">The current agent configuration and capabilities</param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAgent([FromBody]RegisterAgentPayload payload)
        {
            var measures = payload.Measures.Select(m => new AgentMeasure(m.Name, m.Unit, m.Type));

            var result = await _mediator.Send(new RegisterAgentCommand(payload.Name, measures));
            if (result.status == RegistrationResult.Success)
                return Ok(new { result.mqtt });

            return StatusCode(500);
        }
    }
}
