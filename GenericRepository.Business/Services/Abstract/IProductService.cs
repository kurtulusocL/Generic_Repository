using GenericRepository.Entities.Entities;

namespace GenericRepository.Business.Services.Abstract
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<IEnumerable<Product>> GetAllProductByCategoryIdAsync(int id);
        Task<IEnumerable<Product>> GetAllProductByWarehouseIdAsync(int id);       
        Task<Product> GetProductAsync(int? id);
        Task<bool> CreateAsync(Product entity);
        Task<bool> UpdateAsync(Product entity);
        Task<bool> DeleteAsync(Product entity);
    }
}
