using Api.Domain.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class Product :EntityBase
    {
        public Product()
        {
            
        }

        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int BrandId { get; set; }
        public required decimal Discunt { get; set; }
        public Brand Brand { get; set; }    
        public ICollection<Category> Categories { get; set; }

    }
}
