using System.Threading.Tasks;
namespace Shop.Api.Domain.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}