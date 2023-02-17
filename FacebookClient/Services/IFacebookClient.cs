using System;
using System.Threading.Tasks;

namespace Ukim.FacebookAPIClient.Services
{
    public interface IFacebookClient
    {
        Task<T> GetAsync<T>(string accessToken, string endpoint, string args = null);
    }
}
