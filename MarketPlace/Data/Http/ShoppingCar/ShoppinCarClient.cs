using System.Net.Http.Headers;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using CreditAppWeb.Data.Http.Products;
using Newtonsoft.Json;

namespace CreditAppWeb.Data.Http.ShoppingCar;

public class ShoppinCarClient
{
    private readonly HttpClient httpClient;
    private readonly ILocalStorageService localStorage;

    public ShoppinCarClient(HttpClient httpClient, ILocalStorageService localStorage)
    {
        this.httpClient = httpClient;
        this.localStorage = localStorage;
    }

    public async Task<GetShoopinCarDTO> AddProductsCar(List<int> productId)
    {
        var request = new AddProductRequest();
        request.ProductId = productId;
        var token = await localStorage.GetItemAsync<string>("token");
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await httpClient.PutAsJsonAsync("AddProductCar", request);
        var responseString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<GetShoopinCarDTO>(responseString);
    }
}