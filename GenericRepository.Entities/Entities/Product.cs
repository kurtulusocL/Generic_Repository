using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository.Core.Entities.Concrete;

namespace GenericRepository.Entities.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public decimal Price { get; set; }
        public int UnitInStock { get; set; }

        public int CategoryId { get; set; }
        public int WarehouseId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
