using MyBlog.Models.Domain;

namespace MyBlog.Repositories
{
    public interface IBlogPostRepository 
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();

        Task<BlogPost?> GetAsync(Guid id);
        
        Task<BlogPost?> GetByUrlHandleAsync(string urlHandle);
        Task<BlogPost> AddAsync(BlogPost blogPost);

        Task<BlogPost?> UpdateAsync(BlogPost blogPost);

        Task<BlogPost?> DeleteAsync(Guid id);

        Task<IEnumerable<BlogPost>> GetByCategoryAsync(Guid categoryId);

        Task<IEnumerable<BlogPost>> GetByCategoryUrlHandleAsync(string categoryUrlHandle);

        Task<IEnumerable<BlogPost>> GetByCategoryAsync(string urlHandle);


    }
}
