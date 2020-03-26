using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.Api.Domain.Models;
using Shop.Api.Domain.Repositories;
using Shop.Api.Domain.Services;
using Shop.Api.Domain.Services.Communication;

namespace Shop.Api.Services
{
    public class CategoryService : IService<Category, CategoryResponse>
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public CategoryService(IRepository<Category> repository, IUnitOfWork unitOfWork)
        {
            categoryRepository = repository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var existingCategory = await categoryRepository.FindByIdAsync(id);
            if(existingCategory==null)
                return new CategoryResponse("Good not found");

            try
            {
                categoryRepository.Remove(existingCategory);
                await unitOfWork.CompleteAsync();
                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
               return new CategoryResponse($"Category delete error:${ex.Message}");
            }
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await categoryRepository.ListAllAsync();
        }

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await categoryRepository.AddAsync(category);
                await unitOfWork.CompleteAsync();

                return new CategoryResponse(category);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"Error saving category:{ex.Message}");
            }
        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            var existingCategory = await categoryRepository.FindByIdAsync(id);
            if (existingCategory == null)
                return new CategoryResponse("Category not found");

            existingCategory.Name = category.Name;

            try
            {
                categoryRepository.Update(existingCategory);
                await unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex)
            {
                return new CategoryResponse($"Update error: {ex.Message}");
            }
        }
    }
}