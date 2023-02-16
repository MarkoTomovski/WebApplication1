using System;
using FacebookAPIClient.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FacebookAPIClient
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
