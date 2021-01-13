using Shop.Core.Entities;
using System.Collections.Generic;

namespace Shop.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
