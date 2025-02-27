using GenericRepository.Core.DataAccess;
using GenericRepository.DataAccess.Abstract;
using GenericRepository.DataAccess.Concrete.EntityFramework.Context;
using GenericRepository.Entities.Entities;

namespace GenericRepository.DataAccess.Concrete.EntityFramework
{
    public class CategoryDal : EntityRepositoryBase<Category, ApplicationDbContext>, ICategoryDal
    {
    }
}
