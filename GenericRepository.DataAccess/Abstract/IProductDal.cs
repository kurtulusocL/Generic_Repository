using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository.Core.DataAccess.EntityFramework;
using GenericRepository.Entities.Entities;

namespace GenericRepository.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
    }
}
