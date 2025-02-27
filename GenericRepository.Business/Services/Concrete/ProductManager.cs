using GenericRepository.Business.Services.Abstract;
using GenericRepository.DataAccess.Abstract;
using GenericRepository.Entities.Entities;

namespace GenericRepository.Business.Services.Concrete
{
    public class ProductManager : IProductService
    {
        readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task<bool> CreateAsync(Product entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }
                return await _productDal.AddAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public  async Task<bool> DeleteAsync(Product entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }
                return await _productDal.DeleteAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var result = await _productDal.GetAllIncludingAsync("Warehouse,Category");
            return result.OrderByDescending(i => i.CreatedDate).ToList();
        }

        public async Task<IEnumerable<Product>> GetAllProductByCategoryIdAsync(int id)
        {
            var result = await _productDal.GetAllIncludingAsync("Warehouse,Category");
            return result.Where(i => i.CategoryId == id).ToList();
        }

        public async Task<IEnumerable<Product>> GetAllProductByWarehouseIdAsync(int id)
        {
            var result = await _productDal.GetAllIncludingAsync("Warehouse,Category");
            return result.Where(i => i.WarehouseId == id).ToList();
        }

        public async Task<Product> GetProductAsync(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new ArgumentNullException(nameof(id));
                }
                return await _productDal.GetAsync(i => i.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(Product entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }
                return await _productDal.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
