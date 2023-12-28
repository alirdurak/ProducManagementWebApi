using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProducManagementWebApi.Models;
using System.Linq;

namespace ProducManagementWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        static int id = 4;
        private static List<Category> categories = new List<Category>() {
                new Category { Id = 1, Name = "Bilgisayar",IsStatus=true },
                new Category { Id = 2, Name = "Telefon",IsStatus=true },
                new Category { Id = 3, Name = "Tablet",IsStatus=true },
                new Category { Id = 4, Name = "Beyaz Eşya",IsStatus=false },
            };
        [HttpGet]
        //...api/Category
        public IEnumerable<Category> GetAll()
        {
            return categories.ToList();
        }

        [HttpGet("{id}")]
        public Category Get(int id)
        {
            var category = categories.FirstOrDefault(x => x.Id == id);
            return category;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = categories.FirstOrDefault(x => x.Id == id);
            if (category != null)
            {
                var products = ProductController.products.Where(item => item.CategoryId == id).ToList();
                if (products.Count() > 0)
                {
                    foreach (var item in products)
                    {

                        ProductController.products.Remove(item);
                    }
                }
                categories.Remove(category);
                return StatusCode(200);
            };
            return StatusCode(404);


        }

        [HttpPost]
        public IActionResult Post(Category category)
        {
            if (!String.IsNullOrEmpty(category.Name))
            {
                id++;
                category.Id = id;
                categories.Add(category);
                return Ok("Ekleme Başarılı!");
            }
            return Ok("Category Name Boş Olamaz");
        }

        [HttpPut]
        public IActionResult Put(Category category)
        {
            var findCategory = categories.FirstOrDefault(x => x.Id == category.Id);

            if (findCategory != null)
            {
                findCategory.Name = category.Name;
                findCategory.IsStatus = category.IsStatus;
                return Ok(category.Name + " " + "İsimli kategori güncellendi");
            }
            return Ok("Kategori Bulunamadı");


        }
        [HttpPut("{id}")]
        public IActionResult Put2(int id,Category category)
        {
            var findCategory = categories.FirstOrDefault(x => x.Id == id);
            if (findCategory != null)
            {
                findCategory.Name = category.Name;
                findCategory.IsStatus = category.IsStatus;
                return Ok(category.Name + " " + "İsimli kategori güncellendi");
            }
            return Ok("Kategori Bulunamadı");
        }





    }
}
