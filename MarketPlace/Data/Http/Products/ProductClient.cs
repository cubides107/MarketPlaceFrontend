using System.Net.Http.Headers;
using System.Net.Http.Json;
using Blazored.LocalStorage;

namespace CreditAppWeb.Data.Http.Products;

public class ProductClient
{
    private readonly HttpClient httpClient;
    private readonly ILocalStorageService localStorage;

    public ProductClient(HttpClient httpClient, ILocalStorageService localStorage)
    {
        this.httpClient = httpClient;
        this.localStorage = localStorage;
    }
    
    public async Task<string> RegisterProduct(ProductRequestDTO product)
    {
        var token = await localStorage.GetItemAsync<string>("token");
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var idUser = await httpClient.PutAsJsonAsync("RegisterProduct", product);
        return await idUser.Content.ReadAsStringAsync();
    }
}