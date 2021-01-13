using Shop.Core.Entities;
using System.Collections.Generic;

namespace Shop.Entities.Concrete
{
    public class Role : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
