using System;
using System.Threading.Tasks;
using Application.Persons;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class FantasyTeamController : BaseAPIController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFantasyTeam(Guid id)
        {
            return HandleRequest(await Mediator.Send(new Application.FantasyTeams.DetailsByTeamID.Query { FantasyTeamID = id }));
        }

        [HttpGet("PersonID/{id}")]
        public async Task<IActionResult> GetFantasyTeamByPerson(Guid id)
        {
            return HandleRequest(await Mediator.Send(new Application.FantasyTeams.DetailsByPlayerID.Query { PersonID = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateFantasyTeam([FromBody] FantasyTeam fantasyTeam)
        {
            return HandleRequest(await Mediator.Send(new Application.FantasyTeams.Create.Command { FantasyTeam = fantasyTeam }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditFantasyTeam(Guid id, FantasyTeam fantasyTeam)
        {
            fantasyTeam.FantasyTeamID = id;
            return HandleRequest(await Mediator.Send(new Application.FantasyTeams.Edit.Command { FantasyTeam = fantasyTeam }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFantasyTeam(Guid id)
        {
            return HandleRequest(await Mediator.Send(new Application.FantasyTeams.Delete.Command { FantasyTeamID = id }));
        }
    }
}