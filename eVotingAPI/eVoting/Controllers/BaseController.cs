using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eVoting.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator;
        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
