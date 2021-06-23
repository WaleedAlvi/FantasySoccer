using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Persons;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PlayerController : BaseAPIController
    {
        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            return HandleRequest(await Mediator.Send(new Application.Players.List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayer(Guid id)
        {
            return HandleRequest(await Mediator.Send(new Application.Players.Details.Query { PlayerID = id }));
        }

        [HttpGet("TeamID/{id}")]
        public async Task<IActionResult> GetPlayerByTeam(Guid id)
        {
            return HandleRequest(await Mediator.Send(new Application.Players.ListByTeam.Query { TeamID = id }));
        }
    }
}