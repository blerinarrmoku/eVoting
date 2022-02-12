using eVoting.App.Abstraction.Services.Contacts;
using eVoting.Model.Contacts.Commands.CreateContact;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace eVoting.App.Handlers.Comtacts.Commands.CreateContact
{
    public class CreateContactHandler : IRequestHandler<CreateContactCommand, CreateContactResponse>
    {
        private readonly ILogger<CreateContactHandler> _logger;
        private readonly IContactService _contactService;

        public CreateContactHandler(
            ILogger<CreateContactHandler> logger,
            IContactService contactService)
        {
            _logger = logger;
            _contactService = contactService;
        }

        public Task<CreateContactResponse> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
