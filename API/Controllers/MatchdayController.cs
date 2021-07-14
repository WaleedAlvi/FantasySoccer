using System;
using System.Threading.Tasks;
using Application.Matchdays;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MatchdayController : BaseAPIController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatchdayTeam(Guid id)
        {
            return HandleRequest(await Mediator.Send(new Application.Matchdays.Details.Query { FantasyTeamID = id }));
        }
        [HttpPost("Configuration")]
        public async Task<IActionResult> AddMatchdayTeamConfig([FromBody] MatchdayTeamConfigDto matchdayTeamConfig)
        {
            return HandleRequest(await Mediator.Send(new Application.Matchdays.CreateConfiguration.Command { MatchdayTeamConfig = matchdayTeamConfig }));
        }

        [HttpPost("Team/{id}")]
        public async Task<IActionResult> AddMatchdayTeam(Guid id, [FromBody] MatchdayTeamDto matchdayTeam)
        {
            matchdayTeam.MatchdayTeamConfigurationID = id;
            return HandleRequest(await Mediator.Send(new Application.Matchdays.CreateTeam.Command { MatchdayTeam = matchdayTeam }));
        }

        [HttpPut("Configuration/{id}")]
        public async Task<IActionResult> EditMatchdayTeamConfig(Guid id, MatchdayTeamConfiguration matchdayTeamConfig)
        {
            matchdayTeamConfig.MatchdayTeamConfigurationID = id;
            return HandleRequest(await Mediator.Send(new Application.Matchdays.EditConfiguration.Command { matchdayTeamConfig = matchdayTeamConfig }));
        }

        [HttpPut("Team/{id}")]
        public async Task<IActionResult> EditMatchdayTeam(Guid id, MatchdayTeam matchdayTeam)
        {
            matchdayTeam.MatchdayTeamID = id;
            return HandleRequest(await Mediator.Send(new Application.Matchdays.EditTeam.Command { MatchdayTeam = matchdayTeam }));
        }
    }
}