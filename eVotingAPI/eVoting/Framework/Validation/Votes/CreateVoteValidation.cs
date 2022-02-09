using eVoting.Model.Votes.Commands.CreateVote;
using FluentValidation;

namespace eVoting.App.Framework.Validation.Votes
{
    public class CreateVoteValidation : AbstractValidator<CreateVoteCommand>
    {
        public CreateVoteValidation()
        {
            RuleFor(x => x.CandidateId)
                .NotNull()
                .WithMessage("Candidate Id can not be null!");

            RuleFor(x => x.CandidateId)
                .NotEmpty()
                .WithMessage("Candidate Id not be empty!");

            RuleFor(x => x.CandidateId)
                .NotEqual(0)
                .WithMessage("Candidate Id must be provided!");

            RuleFor(x => x.PartyId)
                .NotNull()
                .WithMessage("Candidate Id can not be null!");

            RuleFor(x => x.PartyId)
                .NotEmpty()
                .WithMessage("Candidate Id not be empty!");

            RuleFor(x => x.PartyId)
                .NotEqual(0)
                .WithMessage("Candidate Id must be provided!");

            RuleFor(x => x.UserId)
                .NotNull()
                .WithMessage("User Id can not be null!");

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("User Id not be empty!");
        }
    }
}
