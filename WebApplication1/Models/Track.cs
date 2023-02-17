namespace Ukim.MusicAPI.Models
{
    public class Track
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public MusicPlatformType PublishedOn { get; set; }

        public string? PublishURL { get; set; }
    }
}
