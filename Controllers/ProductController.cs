using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProducManagementWebApi.Models;

namespace ProducManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        static int id = 4;
        public static List<Product> products = new List<Product>() {
                new Product { Id = 1, Name = "Dell",IsStatus=true,Price=20000,Stock=12,CategoryId=1 },
                new Product { Id = 2, Name = "Iphone",IsStatus=true,Price=50000,Stock=100,CategoryId=2 },
                new Product { Id = 3, Name = "Matepad",IsStatus=true,Price=16000,Stock=25,CategoryId=3 },
                new Product { Id = 4, Name = "Buzdolabı",IsStatus=false,Price=28000,Stock=14,CategoryId=4 },
            };
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return products.ToList();
        }


        [HttpGet("{id}")]
        public Product Get(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            return product;

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                products.Remove(product);
                return StatusCode(200);
            };
            return StatusCode(404);


        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            if (!String.IsNullOrEmpty(product.Name) || product.CategoryId != 0)
            {
                id++;
                product.Id = id;
                products.Add(product);
                return Ok("Ekleme Başarılı!");
            }
            return Ok("Eksik bilgi girildi");
        }


        [HttpPut("{id}")]
        public IActionResult Put2(int id, Product product)
        {
            var findProduct = products.FirstOrDefault(x => x.Id == id);
            if (findProduct != null)
            {
                findProduct.Name = product.Name;
                findProduct.IsStatus = product.IsStatus;
                findProduct.Price = product.Price;
                findProduct.Stock = product.Stock;
                findProduct.CategoryId = product.CategoryId;
                return Ok(product.Name + " " + "İsimli ürün güncellendi");
            }
            return Ok("Ürün Bulunamadı");
        }


    }


}
