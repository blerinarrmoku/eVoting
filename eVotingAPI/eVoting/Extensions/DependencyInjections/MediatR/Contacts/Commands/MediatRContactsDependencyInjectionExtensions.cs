using eVoting.App.Handlers.Comtacts.Commands.CreateContact;
using eVoting.Model.Contacts.Commands.CreateContact;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace eVoting.App.Extensions.DependencyInjections.MediatR.Contacts.Commands
{
    public static class MediatRContactsDependencyInjectionExtensions
    {
        public static void AddContactsQuery(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CreateContactCommand, CreateContactResponse>, CreateContactHandler>();
        }
    }
}
