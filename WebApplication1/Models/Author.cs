namespace Ukim.MusicAPI.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public AuthorType Type { get; set; }

        public string FbPage { get; set; }

        public List<FbPost> FbPosts { get; set; }
    }
}
