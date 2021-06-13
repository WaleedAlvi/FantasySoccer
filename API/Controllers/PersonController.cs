using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Persons;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PersonsController : BaseAPIController
    {
        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetPersons()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(Guid id)
        {
            return await Mediator.Send(new Details.Query { PersonID = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] Person person)
        {
            return Ok(await Mediator.Send(new Create.Command { Person = person }));
        }
    }
}