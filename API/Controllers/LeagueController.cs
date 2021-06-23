using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Persons;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class LeaguesController : BaseAPIController
    {
        [HttpGet]
        public async Task<IActionResult> GetLeagues()
        {
            return HandleRequest(await Mediator.Send(new Application.Leagues.List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeague(int id)
        {
            return HandleRequest(await Mediator.Send(new Application.Leagues.Details.Query { APIFootballID = id }));
        }
    }
}