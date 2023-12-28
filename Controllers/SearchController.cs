using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProducManagementWebApi.Models;

namespace ProducManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        [HttpGet("{item?}/{page?}")]
        public ProductPaginationModel Get(string item,int page=1)
        {
            var model = new ProductPaginationModel();
            int productCount = 5;
            var productList = ProductController.products.Where(x=>x.Name.Contains(item) ).Skip(productCount * (page - 1)).Take(productCount).ToList();
            model.TotalPrductCount = ProductController.products.Count;
            model.CurentPage = page;
            model.Products = productList;
            model.PageCount = (int)Math.Ceiling(productList.Count / 5.0);
            return model;
        }
    }
}
