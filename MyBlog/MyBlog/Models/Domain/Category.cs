namespace MyBlog.Models.Domain
{
    public class Category
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string UrlHandle { get; set; }
        
        public bool Visible { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public ICollection<BlogPost> BlogPosts { get; set; }
    }
} 