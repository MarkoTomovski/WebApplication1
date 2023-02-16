using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.EntityFrameworkCore;

using MusicAPI.Models;

namespace MusicAPI.Data
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasKey(c => c.Id);

            modelBuilder.Entity<Contributor>().HasKey(c => c.Id);

            modelBuilder.Entity<FbPost>().HasKey(c => c.Id);

            modelBuilder.Entity<Author>().HasKey(a => a.Id);
            modelBuilder.Entity<Author>()
                .HasMany(a => a.FbPosts);

            modelBuilder.Entity<Track>().HasKey(t => t.Id);

            modelBuilder.Entity<Album>().HasKey(a => a.Id);
            modelBuilder.Entity<Album>()
                .HasOne(c => c.Category);
            modelBuilder.Entity<Album>()
                .HasMany(a => a.Authors);
            modelBuilder.Entity<Album>()
                .HasMany(a => a.Contributors);
            modelBuilder.Entity<Album>()
                .HasMany(a => a.Tracks);
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Contributor> Contributors { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<FbPost> FbPosts { get; set; }
    }
}
