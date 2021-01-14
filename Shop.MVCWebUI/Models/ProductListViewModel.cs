using Shop.Entities.Concrete;
using System.Collections.Generic;

namespace Shop.MVCWebUI.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}