namespace WebApplication1
{
    public class Category
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }

        public List<Artists> artists { get; set; }
    }
}
