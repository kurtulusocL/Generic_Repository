using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository.Entities.Entities;

namespace GenericRepository.Business.Services.Abstract
{
    public interface IWarehouseService
    {
        Task<IEnumerable<Warehouse>> GetAllAsync();
        Task<IEnumerable<Warehouse>> GetWarehouseForAddProductAsync();
        Task<Warehouse> GetWarehouseAsync(int? id);
        Task<bool> CreateAsync(Warehouse entity);
        Task<bool> UpdateAsync(Warehouse entity);
        Task<bool> DeleteAsync(Warehouse entity);
    }
}
