using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class MusicAppDBContext : DbContext
    {
        public MusicAppDBContext(DbContextOptions<MusicAppDBContext> options) : base(options)
        {

        }
        public DbSet<Album> album { get; set; }
    }
}
