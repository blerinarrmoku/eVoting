using eVoting.App.Models;
using eVoting.Model.Parties.Queries.GetParties;
using eVoting.Model.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoting.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartiesController : BaseController
    {
        private readonly EVotingContext _context;

        public PartiesController(
            EVotingContext context, IMediator mediator) : base(mediator)
        {
            _context = context;
        }

        [HttpGet("allParties")]
        public async Task<ActionResult<ResponseModel<GetPartiesResult>>> GetParties()
        {
            var response = new ResponseModel<GetPartiesResult>();

            var responseContent = await Mediator.Send(new GetPartiesQuery());
            if (responseContent == null)
                return BadRequest(response.AddMessage("Error getting parties!").BadRequest());

            return Ok(response.Ok(responseContent));
        }
    }
}
