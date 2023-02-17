namespace Ukim.MusicAPI.Models
{
    public class Album
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Category Category { get; set; }

        public AlbumType Type { get; set; }

        public List<Author> Authors { get; set; }

        public List<Contributor> Contributors { get; set; }

        public List<Track> Tracks { get; set; }
    }
}
