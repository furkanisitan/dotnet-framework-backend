using Shop.Entities.Concrete;
using System.Collections.Generic;

namespace Shop.MVCWebUI.Models
{
    public class CategoryListViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Category DefaultActiveCategory { get; set; }
    }
}