using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Api.Domain.Models;
using Shop.Api.Domain.Repositories;
using Shop.Api.Persistence.Context;

namespace Shop.Api.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository, IRepository<Category>
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            return await dbContext.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> ListAllAsync()
        {
            return await dbContext.Categories.ToListAsync();
        }

        public void Remove(Category category)
        {
           dbContext.Categories.Remove(category);
        }

        public void Update(Category category)
        {
            dbContext.Categories.Update(category);
        }
    }
}