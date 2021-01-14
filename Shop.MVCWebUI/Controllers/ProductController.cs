using Shop.Business.Abstract;
using Shop.MVCWebUI.Models;
using System.Web.Mvc;

namespace Shop.MVCWebUI.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult ProductList(int categoryId)
        {
            var productListVm = new ProductListViewModel
            {
                Products = categoryId > 0 ? _productService.GetAllByCategoryId(categoryId) : _productService.GetAll()
            };

            return PartialView(productListVm);
        }
    }
}