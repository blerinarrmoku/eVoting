using MediatR;

namespace eVoting.Model.Contacts.Commands.CreateContact
{
    public class CreateContactCommand : IRequest<CreateContactResponse>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

    }
}
