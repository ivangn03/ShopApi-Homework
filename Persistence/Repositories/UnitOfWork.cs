using System.Threading.Tasks;
using Shop.Api.Domain.Repositories;
using Shop.Api.Persistence.Context;

namespace Shop.Api.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private  readonly AppDbContext dbContext;
        public UnitOfWork(AppDbContext context)
        {
            dbContext = context;
        }
        public async Task CompleteAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}