using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Ukim.FacebookAPIClient.Models;

namespace Ukim.FacebookAPIClient.Services
{
    public class FacebookService : IFacebookService
    {
        private readonly IFacebookClient _facebookClient;

        public FacebookService(IFacebookClient facebookClient)
        {
            _facebookClient = facebookClient;
        }

        public async Task<Account> GetAccountAsync(string accessToken)
        {
            var result = await _facebookClient.GetAsync<dynamic>(
                accessToken, "me", "fields=id,name,email,first_name,last_name,age_range,birthday,gender,locale");

            if (result == null)
            {
                return new Account();
            }

            var account = new Account
            {
                Id = result.id,
                Email = result.email,
                Name = result.name,
                UserName = result.username,
                FirstName = result.first_name,
                LastName = result.last_name,
                Locale = result.locale
            };

            return account;
        }

        public Task<Feed> GetFeedAsync(string page, string accessToken)
        {
            //TODO: implement call

            return Task.FromResult(new Feed()
            {
                Posts = new List<Post>()
                {
                    { new Post() { Id = Guid.NewGuid().ToString(), Timestamp = DateTime.Now, Content = "<html><body><h1>Test post</h1></body></html>" } }
                }
            });
        }
    }
}
