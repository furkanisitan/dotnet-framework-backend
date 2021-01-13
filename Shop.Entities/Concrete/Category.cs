using Shop.Core.Entities;
using System.Collections.Generic;

namespace Shop.Entities.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
