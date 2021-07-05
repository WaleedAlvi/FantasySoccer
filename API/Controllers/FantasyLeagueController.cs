using System;
using System.Threading.Tasks;
using Application.FantasyLeagues;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class FantasyLeagueController : BaseAPIController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFantasyLeague(Guid id)
        {
            return HandleRequest(await Mediator.Send(new Application.FantasyLeagues.Detail.Query { FantasyLeagueID = id }));
        }

        [HttpGet("Key/{key}")]
        public async Task<IActionResult> GetFantasyLeagueByKey(string key)
        {
            return HandleRequest(await Mediator.Send(new Application.FantasyLeagues.DetailByKey.Query { LeagueKey = key }));
        }

        [HttpGet("Public")]
        public async Task<IActionResult> GetPersons()
        {
            return HandleRequest(await Mediator.Send(new Application.FantasyLeagues.PublicLeagueList.Query()));
        }

        [HttpGet("Person/{id}")]
        public async Task<IActionResult> GetPersons(Guid id)
        {
            return HandleRequest(await Mediator.Send(new Application.FantasyLeagues.PersonActiveLeagues.Query { PersonID = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateFantasyLeague([FromBody] FantasyLeagueCreateDto fantasyLeague)
        {
            return HandleRequest(await Mediator.Send(new Application.FantasyLeagues.Create.Command { FantasyLeague = fantasyLeague }));
        }

        [HttpPost("FantasyTeam")]
        public async Task<IActionResult> AddFantasyTeam([FromBody] FantasyLeagueTeamDto fantasyLeagueTeam)
        {
            return HandleRequest(await Mediator.Send(new Application.FantasyLeagues.InsertTeam.Command { FantasyLeagueTeam = fantasyLeagueTeam }));
        }

        [HttpPost("Admin")]
        public async Task<IActionResult> AddAdmin([FromBody] FantasyLeagueAdminDto fantasyLeagueAdmin)
        {
            return HandleRequest(await Mediator.Send(new Application.FantasyLeagues.InsertLeagueAdmin.Command { FantasyLeagueAdmin = fantasyLeagueAdmin }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditFantasyLeague(Guid id, FantasyLeague fantasyLeague)
        {
            fantasyLeague.FantasyLeagueID = id;
            return HandleRequest(await Mediator.Send(new Application.FantasyLeagues.Edit.Command { FantasyLeague = fantasyLeague }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFantasyLeague(Guid id)
        {
            return HandleRequest(await Mediator.Send(new Application.FantasyLeagues.Delete.Command { FantasyLeagueID = id }));
        }

        [HttpDelete("FantasyTeam")]
        public async Task<IActionResult> DeleteFantasyTeam([FromBody] FantasyLeagueTeamDto fantasyLeagueTeam)
        {
            return HandleRequest(await Mediator.Send(new Application.FantasyLeagues.DeleteTeam.Command { FantasyLeagueTeam = fantasyLeagueTeam }));
        }

        [HttpDelete("Admin")]
        public async Task<IActionResult> DeleteAdmin([FromBody] FantasyLeagueAdminDto fantasyLeagueAdmin)
        {
            return HandleRequest(await Mediator.Send(new Application.FantasyLeagues.DeleteLeagueAdmin.Command { FantasyLeagueAdmin = fantasyLeagueAdmin }));
        }
    }
}