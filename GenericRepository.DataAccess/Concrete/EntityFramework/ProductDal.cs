using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository.Core.DataAccess;
using GenericRepository.DataAccess.Abstract;
using GenericRepository.DataAccess.Concrete.EntityFramework.Context;
using GenericRepository.Entities.Entities;

namespace GenericRepository.DataAccess.Concrete.EntityFramework
{
    public class ProductDal:EntityRepositoryBase<Product,ApplicationDbContext>,IProductDal
    {
    }
}
