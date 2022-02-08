using eVoting.App.ViewModels;
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
    public class VotesController : ControllerBase
    {
        [HttpPost("Vote")]
        public async Task<ActionResult> Vote(VotingViewModel model)
        {

            return Ok(true);
        }
    }
}
