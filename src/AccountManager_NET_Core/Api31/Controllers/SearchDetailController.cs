using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api31.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Api31.Services.UseCase;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api31.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchDetailController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SearchDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<AccountDetail>> GetAsync([FromBody] long userAccountId, 
            [FromQuery] string remarks, [FromQuery] string fromString, [FromQuery] string toString)
        {
            var command = new SearchDetailQuery(userAccountId, remarks, fromString, toString);
            var result = await _mediator.Send(command);

            return result;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
