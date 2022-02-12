using eVoting.App.Handlers.Members.Commands.CreateMember;
using eVoting.Model.Members.Commands.CreateMember;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace eVoting.App.Extensions.DependencyInjections.MediatR.Members.Commands
{
    public static class MediatRMembersDependencyInjectionExtensions
    {
        public static void AddMembersCommandHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<CreateMemberCommand, CreateMemberResponse>, CreateMemberHandler>();
        }
    }
}
