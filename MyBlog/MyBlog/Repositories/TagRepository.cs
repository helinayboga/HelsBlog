using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MyBlog.Data;
using MyBlog.Models.Domain;

namespace MyBlog.Repositories
{
    public class TagRepository : ITagRepository
    {

        private readonly MyBlogDbContext _dbContext;

        public TagRepository(MyBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Tag?> AddAsync(Tag tag)
        {
            await _dbContext.AddAsync(tag);
            await _dbContext.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
           var existingTag= await _dbContext.Tags.FindAsync(id);
            if (existingTag != null)
            {
                _dbContext.Tags.Remove(existingTag);
                await _dbContext.SaveChangesAsync();
                return existingTag;
            }
            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await _dbContext.Tags.ToListAsync();
        }

        public async Task<Tag?> GetAsync(Guid id)
        {
            return await _dbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await _dbContext.Tags.FindAsync(tag.Id);

            if (existingTag != null)
            {
                existingTag.Name = tag.Name;

                await _dbContext.SaveChangesAsync();
                return existingTag;

            }
            return null;
           
        }
    }
}
