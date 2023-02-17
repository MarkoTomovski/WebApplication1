using System;
using System.Threading.Tasks;

using Ukim.FacebookAPIClient.Models;

namespace Ukim.FacebookAPIClient.Services
{
    public interface IFacebookService
    {
        Task<Account> GetAccountAsync(string accessToken);

        Task<Feed> GetFeedAsync(string page, string accessToken);
    }
}
