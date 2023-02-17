using System;

using Microsoft.Extensions.DependencyInjection;

using Ukim.FacebookAPIClient.Services;

namespace Ukim.FacebookAPIClient
{
    public static class Extensions
    {
        public static void AddFacebookService(this IServiceCollection services)
        {
            services.AddTransient<IFacebookClient, FacebookClient>();
            services.AddTransient<IFacebookService, FacebookService>();
        }
    }
}
