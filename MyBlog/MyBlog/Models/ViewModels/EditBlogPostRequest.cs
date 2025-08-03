using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyBlog.Models.ViewModels
{
    public class EditBlogPostRequest
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ShortDescription { get; set; }

        public string FeaturedImageUrl { get; set; }

        public string UrlHandle { get; set; }

        public DateTime? PublishedDate { get; set; }

        public string Author { get; set; }

        public bool Visible { get; set; }

        public Guid? CategoryId { get; set; }

        //Display tags
        public IEnumerable<SelectListItem> Tags { get; set; }

        //Display categories
        public IEnumerable<SelectListItem> Categories { get; set; }

        //Collect tags
        public string[] SelectedTags { get; set; } = Array.Empty<string>();

    }
}
