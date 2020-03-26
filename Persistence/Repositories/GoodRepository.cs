using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Api.Domain.Models;
using Shop.Api.Domain.Repositories;
using Shop.Api.Persistence.Context;

namespace Shop.Api.Persistence.Repositories
{
    public class GoodRepository : BaseRepository, IRepository<Good>
    {
        public GoodRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Good good)
        {
            await dbContext.Goods.AddAsync(good);
        }

        public async Task<Good> FindByIdAsync(int id)
        {
            return await dbContext.Goods.FindAsync(id);
        }

        public async Task<IEnumerable<Good>> ListAllAsync()
        {
            return await dbContext.Goods.ToListAsync();
        }

        public void Remove(Good good)
        {
             dbContext.Goods.Remove(good);
             
        }

        public void Update(Good good)
        {
            dbContext.Goods.Update(good);
        }
    }
}