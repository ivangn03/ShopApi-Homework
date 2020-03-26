using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Api.Domain.Services
{
    public interface IService<Model, Response> where Model:class where Response:class
    {
         Task<IEnumerable<Model>> ListAsync();
         Task<Response> SaveAsync(Model model);
         Task<Response> UpdateAsync(int id, Model model);
         Task<Response> DeleteAsync(int id);
    }
}