using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.Api.Domain.Models;
using Shop.Api.Domain.Services;
using Shop.Api.Domain.Repositories;
using Shop.Api.Domain.Services.Communication;
using System;

namespace Shop.Api.Services
{
    public class GoodService : IService<Good,GoodResponse>
    {
        private readonly IRepository<Good> goodRepository;
        private readonly IUnitOfWork unitOfWork;
        public GoodService(IRepository<Good> repository, IUnitOfWork unitOfWork)
        {
            goodRepository = repository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<GoodResponse> DeleteAsync(int id)
        {
            var existingGood = await goodRepository.FindByIdAsync(id);
            if(existingGood==null)
                return new GoodResponse("Good not found");

            try
            {
                goodRepository.Remove(existingGood);
                await unitOfWork.CompleteAsync();
                return new GoodResponse(existingGood);
            }
            catch (Exception ex)
            {
               return new GoodResponse($"Good delete error:${ex.Message}");
            }
        }

        public async Task<IEnumerable<Good>> ListAsync()
        {
            return await goodRepository.ListAllAsync();
        }

        public async Task<GoodResponse> SaveAsync(Good good)
        {
            try
            {
                await goodRepository.AddAsync(good);
                await unitOfWork.CompleteAsync();
                return new GoodResponse(good);
            }
            catch (Exception ex)
            {
                return new GoodResponse($"Saving failed: {ex.Message}");
            }
        }

        public async Task<GoodResponse> UpdateAsync(int id, Good good)
        {
            var existingGood = await goodRepository.FindByIdAsync(id);
            if(existingGood ==null)
                return new GoodResponse("Good not found");
            
            existingGood.Name = good.Name;
            
            try
            {
                goodRepository.Update(existingGood);
                await unitOfWork.CompleteAsync();

                return new GoodResponse(existingGood);
            }
            catch (Exception ex)
            {
                return new GoodResponse($"Update error: {ex.Message}");
            }
            
        }
    }
}