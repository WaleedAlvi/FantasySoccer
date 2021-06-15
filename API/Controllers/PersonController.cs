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
        public async Task<IActionResult> GetPersons()
        {
            return HandleRequest(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(Guid id)
        {
            return HandleRequest(await Mediator.Send(new Details.Query { PersonID = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] Person person)
        {
            return HandleRequest(await Mediator.Send(new Create.Command { Person = person }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPerson(Guid id, Person person)
        {
            person.PersonID = id;
            return HandleRequest(await Mediator.Send(new Edit.Command { Person = person }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            return HandleRequest(await Mediator.Send(new Delete.Command { PersonID = id }));
        }
    }
}