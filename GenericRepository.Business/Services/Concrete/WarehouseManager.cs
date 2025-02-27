using GenericRepository.Business.Services.Abstract;
using GenericRepository.DataAccess.Abstract;
using GenericRepository.Entities.Entities;

namespace GenericRepository.Business.Services.Concrete
{
    public class WarehouseManager : IWarehouseService
    {
        readonly IWarehouseDal _warehouseDal;
        public WarehouseManager(IWarehouseDal warehouseDal)
        {
            _warehouseDal = warehouseDal;
        }
        public async Task<bool> CreateAsync(Warehouse entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }
                return await _warehouseDal.AddAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(Warehouse entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }
                return await _warehouseDal.DeleteAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Warehouse>> GetAllAsync()
        {
            var result= await _warehouseDal.GetAllIncludingAsync("Products");
            return result.OrderByDescending(i => i.CreatedDate).ToList();
        }

        public async Task<Warehouse> GetWarehouseAsync(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new ArgumentNullException(nameof(id));
                }
                return await _warehouseDal.GetAsync(i => i.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Warehouse>> GetWarehouseForAddProductAsync()
        {
            var result = await _warehouseDal.GetAllIncludingAsync("Products");
            return result.OrderByDescending(i => i.Products.Count()).ToList();
        }

        public async Task<bool> UpdateAsync(Warehouse entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }
                return await _warehouseDal.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
