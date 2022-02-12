using eVoting.App.Handlers.Parties.Commands.CreateParty;
using eVoting.Model.Parties.Commands.CreateParty;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace eVoting.App.Extensions.DependencyInjections.MediatR.Parties.Commands
{
    public static class MediatRPartiesDependencyInjectionExtensions
    {
        public static void AddPartyCommandHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CreatePartyCommand, CreatePartyResponse>, CreatePartyHandler>();
        }
    }
}
