using System;

using MusicAPI.Models;

namespace MusicAPI.Data
{
    internal static class MusicDbInitializer
    {
        internal static void SeedStaticData(WebApplication app)
        {
            //data-source: https://www.muzichkiregistar.com/

            var scope = app.Services.CreateScope();
            using var db = scope.ServiceProvider.GetService<MusicDbContext>();

            if (db == null)
            {
                throw new ArgumentException();
            }

            var pop = new Category() { Id = 1, Name = "Pop" };
            var rock = new Category() { Id = 2, Name = "Rock" };
            var jazz = new Category() { Id = 3, Name = "Jazz" };

            db.Categories.Add(pop);
            db.Categories.Add(rock);
            db.Categories.Add(jazz);

            var listContributors1 = new List<Contributor>()
            {
                { new Contributor() { Id = 1, Name = "Никола Перевски - Пере", Type = ContributorType.Singer } },
                { new Contributor() { Id = 2, Name = "Владимир Крстевски - Франц", Type = ContributorType.Guitar } },
                { new Contributor() { Id = 3, Name = "Игор Џамбазов", Type = ContributorType.Text } }
            };

            //db.Contributors.AddRange(listContributors1);

            var listAuthors1 = new List<Author>()
            {
                { new Author() { Id = 1, Name = "Нокаут", Type = AuthorType.Band, FbPage = "NOKAUT.OfficialFanPage" } }
            };
            //db.Authors.AddRange(listAuthors1);

            var listTracks1 = new List<Track>()
            {
                { new Track() { Id = 1, Name = "Добро утро будење" } },
                { new Track() { Id = 2, Name = "Да си тука вечерва" } },
                { new Track() { Id = 3, Name = "Желба", PublishedOn = MusicPlatformType.Youtube, PublishURL = "https://www.youtube.com/watch?v=M3jYXT_KtBg" } },
                { new Track() { Id = 4, Name = "Африка" } },
                { new Track() { Id = 5, Name = "Самовила" } },
                { new Track() { Id = 6, Name = "Запомни, тоа е се што имаме" } },
                { new Track() { Id = 7, Name = "Лебедот бел" } }
            };            

            var listAlbums1 = new List<Album>()
            {
                { new Album() { Id = 1, Category = rock, Name = "Три", Type = AlbumType.LongPlay, Tracks = listTracks1, Authors = listAuthors1, Contributors = listContributors1 } }
            };
            db.Albums.AddRange(listAlbums1);

            db.SaveChanges();
        }
    }
}
