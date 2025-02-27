using GenericRepository.Business.Services.Abstract;
using GenericRepository.DataAccess.Abstract;
using GenericRepository.Entities.Entities;

namespace GenericRepository.Business.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public async Task<bool> CreateAsync(Category entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }
                return await _categoryDal.AddAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(Category entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }
                return await _categoryDal.DeleteAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var result = await _categoryDal.GetAllIncludingAsync("Products");
            return result.OrderByDescending(i => i.CreatedDate).ToList();
        }

        public async Task<IEnumerable<Category>> GetCategoriesForAddProductAsync()
        {
            var result = await _categoryDal.GetAllIncludingAsync("Products");
            return result.OrderByDescending(i => i.Products.Count()).ToList();
        }

        public async Task<Category> GetCategoryAsync(int? id)
        {
            try
            {
                if (id == null)
                {
                    throw new ArgumentNullException(nameof(id));
                }
                return await _categoryDal.GetAsync(i => i.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(Category entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }
                return await _categoryDal.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
