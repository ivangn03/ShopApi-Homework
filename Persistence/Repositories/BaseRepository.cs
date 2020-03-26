using Shop.Api.Persistence.Context;

namespace Shop.Api.Persistence.Repositories
{
    public abstract class BaseRepository
    {
         protected readonly AppDbContext dbContext;
         public BaseRepository(AppDbContext context)
         {
             dbContext = context;
         }
    }
}