using GenericRepository.Entities.Entities;

namespace GenericRepository.Business.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<IEnumerable<Category>> GetCategoriesForAddProductAsync();
        Task<Category> GetCategoryAsync(int? id);
        Task<bool> CreateAsync(Category entity);
        Task<bool> UpdateAsync(Category entity);
        Task<bool> DeleteAsync(Category entity);
    }
}
