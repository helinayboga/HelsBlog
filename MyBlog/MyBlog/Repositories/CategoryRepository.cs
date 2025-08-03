using Microsoft.EntityFrameworkCore;
using MyBlog.Data;
using MyBlog.Models.Domain;

namespace MyBlog.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyBlogDbContext myBlogDbContext;

        public CategoryRepository(MyBlogDbContext myBlogDbContext)
        {
            this.myBlogDbContext = myBlogDbContext;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await myBlogDbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetAsync(Guid id)
        {
            return await myBlogDbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Category?> GetByUrlHandleAsync(string urlHandle)
        {
            return await myBlogDbContext.Categories.FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }

        public async Task<Category> AddAsync(Category category)
        {
            await myBlogDbContext.Categories.AddAsync(category);
            await myBlogDbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> UpdateAsync(Category category)
        {
            var existingCategory = await myBlogDbContext.Categories.FindAsync(category.Id);

            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
                existingCategory.UrlHandle = category.UrlHandle;
                existingCategory.Visible = category.Visible;

                await myBlogDbContext.SaveChangesAsync();
                return existingCategory;
            }

            return null;
        }

        public async Task<Category?> DeleteAsync(Guid id)
        {
            var existingCategory = await myBlogDbContext.Categories.FindAsync(id);

            if (existingCategory != null)
            {
                myBlogDbContext.Categories.Remove(existingCategory);
                await myBlogDbContext.SaveChangesAsync();
                return existingCategory;
            }

            return null;
        }
    }
} 