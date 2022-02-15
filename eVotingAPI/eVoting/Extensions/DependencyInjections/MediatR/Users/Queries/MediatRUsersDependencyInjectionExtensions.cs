using eVoting.App.Handlers.Users.Queries.UserVoted;
using eVoting.Model.Users.Queries.UserVoted;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoting.App.Extensions.DependencyInjections.MediatR.Users.Queries
{
    public static class MediatRUsersDependencyInjectionExtensions
    {
        public static void UserVotedQueryHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<UserVotedQuery, UserVotedResult>, UserVotedHandler>();
        }
    }
}
