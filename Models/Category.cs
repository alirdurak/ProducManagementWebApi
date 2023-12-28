namespace ProducManagementWebApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsStatus { get; set; }  
        public List<Product>? products { get; set; }

    }
}
