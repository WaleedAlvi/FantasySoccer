using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Persons;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TeamController : BaseAPIController
    {
        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            return HandleRequest(await Mediator.Send(new Application.Teams.List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam(Guid id)
        {
            return HandleRequest(await Mediator.Send(new Application.Teams.Details.Query { TeamID = id }));
        }

        [HttpGet("APIFootballID/{id}")]
        public async Task<IActionResult> GetTeamByAPIFootballID(int id)
        {
            return HandleRequest(await Mediator.Send(new Application.Teams.DetailsByAPIFootballID.Query { APIFootballID = id }));
        }
    }
}