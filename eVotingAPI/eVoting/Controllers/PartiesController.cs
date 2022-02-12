using eVoting.App.Models;
using eVoting.Model.Parties.Commands.CreateParty;
using eVoting.Model.Parties.Queries.GetParties;
using eVoting.Model.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("createParty")]
        public async Task<ActionResult<ResponseModel<CreatePartyResponse>>> CreateMember(CreatePartyCommand createMemberCommand)
        {
            var response = new ResponseModel<CreatePartyResponse>();

            var responseContent = await Mediator.Send(createMemberCommand);
            if (responseContent == null)
                return BadRequest(response.AddMessage("Error creating party!").BadRequest());

            return Ok(response.AddMessage("Party has been created").Ok(responseContent));
        }
    }
}
