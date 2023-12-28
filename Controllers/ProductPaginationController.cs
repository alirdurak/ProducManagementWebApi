using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProducManagementWebApi.Models;

namespace ProducManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPaginationController : ControllerBase
    {
        [HttpGet("{page}")]
        public ProductPaginationModel Get(int page=1)
        {
            var model = new ProductPaginationModel();
            int productCount = 5;
            var productList = ProductController.products.Skip(productCount * (page - 1)).Take(productCount).ToList();
            model.TotalPrductCount = ProductController.products.Count;
            model.CurentPage = page;
            model.Products = productList;
            model.PageCount = (int)Math.Ceiling(ProductController.products.Count / 5.0);
            return model;
        }

    }
}
