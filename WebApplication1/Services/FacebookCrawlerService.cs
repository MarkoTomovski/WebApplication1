using FluentScheduler;

using Microsoft.EntityFrameworkCore;

using Ukim.MusicAPI.Data;
using Ukim.MusicAPI.Models;
using Ukim.FacebookAPIClient.Services;

namespace Ukim.MusicAPI.Services
{
    public class FacebookCrawlerService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public FacebookCrawlerService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            JobManager.Initialize();

            JobManager.AddJob(async () => await CrawlAsync(),
                s => s.ToRunEvery(0).Days().At(00, 01)
            );

            return Task.CompletedTask;
        }

        private async Task CrawlAsync()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var facebookService = scope.ServiceProvider.GetService<IFacebookService>();
            var musicDbContext = scope.ServiceProvider.GetService<MusicDbContext>();

            if(facebookService == null || musicDbContext == null) 
            {
                throw new ArgumentException();
            }

            var authors = await musicDbContext.Authors.ToListAsync();

            foreach (var author in authors)
            {
                var dbAuthor = musicDbContext.Authors.Single(a => a.Id == author.Id);
                
                var dailyFeed = await facebookService.GetFeedAsync(author.FbPage, "");
                var dailyFbPosts = new List<FbPost>();
                dailyFeed.Posts.ForEach(p =>
                {
                    dailyFbPosts.Add(new FbPost()
                    {
                        Id = Guid.Parse(p.Id),
                        Timestamp = p.Timestamp,
                        Content = p.Content
                    });
                });
                musicDbContext.FbPosts.AddRange(dailyFbPosts);

                dbAuthor.FbPosts = dailyFbPosts;
                musicDbContext.Update(dbAuthor);

                musicDbContext.SaveChanges();
            }
        }
    }
}
