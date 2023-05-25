namespace CreditAppWeb.Data.Http.Products;

public class ProductRequestDTO
{
    public int Id { get; set; }
    public String Name { get; set; }
    public double Price { get; set; }
    public String Description { get; set; }
    public int Stock { get; set; }
    public String Reference { get; set; } 
}