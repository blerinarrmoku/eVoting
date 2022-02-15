using eVoting.Model.Contacts.Commands.CreateContact;
using eVoting.Model.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoting.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : BaseController
    {

        public ContactController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("createContact")]
        public async Task<ActionResult<ResponseModel<CreateContactResponse>>> CreateMember(CreateContactCommand createContactCommand)
        {
            var response = new ResponseModel<CreateContactResponse>();

            var responseContent = await Mediator.Send(createContactCommand);
            if (responseContent == null)
                return BadRequest(response.AddMessage("Error creating contact!").BadRequest());

            return Ok(response.AddMessage("Mesazhi u ruajt me sukses").Ok(responseContent));
        }
    }
}
