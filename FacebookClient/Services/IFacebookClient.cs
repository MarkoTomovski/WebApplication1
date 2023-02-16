using System;
using System.Threading.Tasks;

namespace FacebookAPIClient.Services
{
    public interface IFacebookClient
    {
        Task<T> GetAsync<T>(string accessToken, string endpoint, string args = null);
    }
}
