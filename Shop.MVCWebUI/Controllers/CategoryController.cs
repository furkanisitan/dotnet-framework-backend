using Shop.Business.Abstract;
using Shop.Entities.Concrete;
using Shop.MVCWebUI.Models;
using System.Web.Mvc;

namespace Shop.MVCWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [ChildActionOnly]
        public ActionResult CategoryList()
        {
            var categoryListVm = new CategoryListViewModel
            {
                Categories = _categoryService.GetAll(),
                DefaultActiveCategory = new Category { Id = -1, Name = "All Products" }
            };

            return PartialView(categoryListVm);
        }
    }
}