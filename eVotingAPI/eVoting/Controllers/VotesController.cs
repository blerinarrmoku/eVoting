using eVoting.App.Models;
using eVoting.App.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly EVotingContext _context;

        public VotesController(EVotingContext context)
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

        [HttpGet("GetPartiesMembers")]
        public List<Member> GetPartiesMembers(int partyId)
        {
            var members = _context.Members.Where(t => t.IsDeleted == false && t.IsCandidate == false && t.PartyId == partyId).ToList();

            return members;
        }

        [HttpPost("Vote")]
        public async Task<ActionResult> Vote(VotingViewModel model)
        {

            return Ok(true);
        }
    }
}
