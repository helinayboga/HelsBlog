using MyBlog.Models.Domain;

namespace MyBlog.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetAsync(Guid id);
        Task<Category?> GetByUrlHandleAsync(string urlHandle);
        Task<Category> AddAsync(Category category);
        Task<Category?> UpdateAsync(Category category);
        Task<Category?> DeleteAsync(Guid id);
    }
} 