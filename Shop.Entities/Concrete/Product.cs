using Shop.Core.Entities;

namespace Shop.Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public short UnitsInStock { get; set; }

        public decimal UnitPrice { get; set; }

        public string Name { get; set; }

        // no virtual => eager loading
        public Category Category { get; set; }
    }
}