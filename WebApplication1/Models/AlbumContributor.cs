namespace Ukim.MusicAPI.Models
{
    public class AlbumContributor
    {
        public int AlbumId { get; set; }

        public int ContributorId { get; set; }

        public Album Album { get; set; }

        public Contributor Contributor { get; set; }
    }
}
