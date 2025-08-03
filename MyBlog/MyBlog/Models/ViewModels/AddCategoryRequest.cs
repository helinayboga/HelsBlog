namespace MyBlog.Models.ViewModels
{
    public class AddCategoryRequest
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string UrlHandle { get; set; }
        
        public bool Visible { get; set; }
    }
} 