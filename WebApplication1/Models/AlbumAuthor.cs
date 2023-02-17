namespace Ukim.MusicAPI.Models
{
    public class AlbumAuthor
    {
        public int AlbumId { get; set; }

        public int AuthorId { get; set; }

        public Album Album { get; set; }

        public Author Author { get; set; }
    }
}
