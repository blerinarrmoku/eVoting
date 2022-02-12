using eVoting.App.Handlers.Members.Queries.GetMembers;
using eVoting.Model.Members.Queries.GetMembers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace eVoting.App.Extensions.DependencyInjections.MediatR.Members.Queries
{
    public static class MediatRMembersDependencyInjectionExtensions
    {
        public static void GetMembersQueryHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<GetMembersQuery, GetMembersResult>, GetMembersHandler>();
        }
    }
}
