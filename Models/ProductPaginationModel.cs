namespace ProducManagementWebApi.Models
{
    public class ProductPaginationModel
    {
        public int CurentPage { get; set; }
        public int PageCount { get; set; }  
        public List<Product> Products { get; set;}
        public int TotalPrductCount { get; set; }   
    }
}
