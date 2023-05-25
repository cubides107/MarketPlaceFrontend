using CreditAppWeb.Data.Http.Products;

namespace CreditAppWeb.Data.Http.ShoppingCar;

public class GetShoopinCarDTO
{
    public List<ProductRequestDTO> Products { get; set; }
    
    public double TotalPrice { get; set; } 
}