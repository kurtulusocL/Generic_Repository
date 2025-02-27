using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository.Core.Entities.Concrete;

namespace GenericRepository.Entities.Entities
{
    public class Warehouse : BaseEntity
    {
        public string Code { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
