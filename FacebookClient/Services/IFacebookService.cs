using System;
using System.Threading.Tasks;

using FacebookAPIClient.Models;

namespace FacebookAPIClient.Services
{
    public interface IFacebookService
    {
        Task<Account> GetAccountAsync(string accessToken);

        Task<Feed> GetFeedAsync(string page, string accessToken);
    }
}
