using eVoting.App.Models;
using eVoting.Model.Members.Commands.CreateMember;
using eVoting.Model.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eVoting.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : BaseController
    {
        private readonly EVotingContext _context;

        public MembersController(
            EVotingContext context, IMediator mediator) : base(mediator)
        {
            _context = context;
        }

        [HttpPost("createMember")]
        public async Task<ActionResult<ResponseModel<CreateMemberResponse>>> CreateMember(CreateMemberCommand createMemberCommand)
        {
            var response = new ResponseModel<CreateMemberResponse>();

            var responseContent = await Mediator.Send(createMemberCommand);
            if (responseContent == null)
                return BadRequest(response.AddMessage("Error creating member!").BadRequest());

            return Ok(response.AddMessage("Member has been created").Ok(responseContent));
        }

    }
}
