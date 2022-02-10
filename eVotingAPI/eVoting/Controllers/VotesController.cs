using eVoting.App.Models;
using eVoting.App.ViewModels;
using eVoting.Model.Response;
using eVoting.Model.Votes.Commands.CreateVote;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoting.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : BaseController
    {
        private readonly EVotingContext _context;

        public VotesController(
            EVotingContext context, IMediator mediator) : base(mediator)
        {
            _context = context;
        }

        [HttpGet("GetVotingList")]
        public VotingList GetVotingList()
        {
            var candidates = _context.Members.Where(t => t.IsDeleted == false && t.IsCandidate == true).ToList();
            var parties = _context.Parties.Where(t => t.IsDeleted == false).ToList();

            var model = new VotingList();
            model.Candidates = candidates;
            model.Parties = parties;

            return model;
        }

        [HttpGet("GetCountedVotes")]
        public CountedVotes GetCountedVotes()
        {
            var model = new CountedVotes();
            model.Candidates = new List<string>();
            model.Votes = new List<int>();
            var members = _context.Votes.Include(t => t.Member).OrderByDescending(t => t.Count);
            foreach(var item in members)
            {
                model.Candidates.Add(item.Member.Name);
                model.Votes.Add(item.Count);
            }

            return model;
        }

        [HttpGet("GetPartiesMembers")]
        public List<Member> GetPartiesMembers(int partyId)
        {
            var members = _context.Members.Where(t => t.IsDeleted == false && t.IsCandidate == false && t.PartyId == partyId).ToList();

            return members;
        }

        //[HttpPost("Vote")]
        //public async Task<ResponseModel<ActionResult<bool>>> Vote(VotingViewModel model)
        //{
        //    var response = new ResponseModel<bool>();
        //    if(model.CheckedCandidates.Count != 5)
        //    {
        //        return BadRequest(response.BadRequest());
        //    }

        //    return Ok(response.Ok(model));
        //}

        [HttpPost("Vote")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseModel<CreateVoteResponse>>> CreateVote(CreateVoteCommand createVoteCommand)
        {
            var response = new ResponseModel<CreateVoteResponse>();
            if(createVoteCommand.CandidateId == 0 || createVoteCommand.PartyId == 0 || createVoteCommand.CheckedCandidates.Count != 5)
            {
                return BadRequest(response.AddMessage("Parameters are not valid!").BadRequest());
            }

            var responseContent = await Mediator.Send(createVoteCommand);
            if (responseContent == null)
                return BadRequest(response.AddMessage("Error happened while creating vote!").BadRequest());

            return Ok(response.AddMessage("Vote has been created").Ok(responseContent));
        }
    }
}
