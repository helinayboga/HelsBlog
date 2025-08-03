using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MyBlog.Controllers;
using MyBlog.Data;
using MyBlog.Models.Domain;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace MyBlog.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly MyBlogDbContext dbContext;

        public BlogPostRepository(MyBlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<BlogPost?> GetByUrlHandleAsync(string urlHandle)
        {
           return await dbContext.BlogPosts.Include(x=>x.Tags).Include(x=>x.Category).
                FirstOrDefaultAsync(x=>x.UrlHandle == urlHandle);
        }

        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await dbContext.AddAsync(blogPost);
            await dbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<BlogPost?> DeleteAsync(Guid id)
        {
            var blogToDelete = await dbContext.BlogPosts.FindAsync(id);
                if(blogToDelete != null)
            {
                dbContext.BlogPosts.Remove(blogToDelete);
                await dbContext.SaveChangesAsync();
                return blogToDelete;
            }
                return null;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await dbContext.BlogPosts.Include(x =>x.Tags).Include(x=>x.Category).ToListAsync();
       
        }

        public async Task<BlogPost?> GetAsync(Guid id)
        {
            return await dbContext.BlogPosts.Include(x => x.Tags).Include(x=>x.Category).FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
           var existingBlog = await dbContext.BlogPosts.Include(x=> x.Tags).Include(x=>x.Category)
           .FirstOrDefaultAsync(x=>x.Id == blogPost.Id);

            if (existingBlog != null)
            {
                existingBlog.Id = blogPost.Id;
                existingBlog.Title = blogPost.Title;
                existingBlog.Content = blogPost.Content;
                existingBlog.Author = blogPost.Author;
                existingBlog.ShortDescription = blogPost.ShortDescription;
                existingBlog.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                existingBlog.UrlHandle = blogPost.UrlHandle;
                existingBlog.PublishedDate = blogPost.PublishedDate;
                existingBlog.Visible = blogPost.Visible;
                existingBlog.CategoryId = blogPost.CategoryId;
                existingBlog.Tags = blogPost.Tags;

                await dbContext.SaveChangesAsync();
                return existingBlog;
            }
            return null;

        }

        public async Task<IEnumerable<BlogPost>> GetByCategoryAsync(Guid categoryId)
        {
            return await dbContext.BlogPosts.Include(x => x.Tags).Include(x => x.Category)
                .Where(x => x.CategoryId == categoryId && x.Visible).ToListAsync();
        }

        public async Task<IEnumerable<BlogPost>> GetByCategoryUrlHandleAsync(string categoryUrlHandle)
        {
            return await dbContext.BlogPosts.Include(x => x.Tags).Include(x => x.Category)
                .Where(x => x.Category.UrlHandle == categoryUrlHandle && x.Visible).ToListAsync();
        }

        /// <summary>
        /// ////////
        /// </summary
        /// <returns></returns>

        public async Task<IEnumerable<BlogPost>> GetByCategoryAsync(string urlHandle)
        {
            return await dbContext.BlogPosts
                .Where(p => p.Category != null && p.Category.UrlHandle == urlHandle)
                .Include(p => p.Category)
                .Include(p => p.Tags)
                .ToListAsync();
        }

    }
}
