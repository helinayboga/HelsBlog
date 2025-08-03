namespace MyBlog.Models.ViewModels
{
    public class EditCategoryRequest
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string UrlHandle { get; set; }
        
        public bool Visible { get; set; }
    }
} 