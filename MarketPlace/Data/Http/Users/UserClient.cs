using System.Net.Http.Headers;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using CreditAppWeb.Data.Http.Users.Requests;

namespace CreditAppWeb.Data.Http.Users;

public class UserClient
{
    private readonly HttpClient httpClient;
    private readonly ILocalStorageService localStorage;

    private string Token;

    public UserClient(HttpClient httpClient, ILocalStorageService localStorage)
    {
        this.httpClient = httpClient;
        this.localStorage = localStorage;
        GetToken();
    }

    private async void GetToken()
    {
        Token = await localStorage.GetItemAsync<string>("token");
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
    }


    public async Task<string> LoginUser(LoginRequest loginRequest)
    {
        var token = await httpClient.PutAsJsonAsync("LoginUser", loginRequest);
        return await token.Content.ReadAsStringAsync();
    }

    public async Task<string> RegisterUser(RegisterUserRequest user)
    {
        var idUser = await httpClient.PutAsJsonAsync("RegisterUser", user);
        return await idUser.Content.ReadAsStringAsync();
    }

    public async Task<ProfileUserRequest> GetUser()
    {
        var token = await localStorage.GetItemAsync<string>("token");
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var user = await httpClient.GetFromJsonAsync<ProfileUserRequest>("GetUser");
        Console.WriteLine(user.Email);
        return user;
    }

    public async Task<bool> IsCheckUpdateUser()
    {
        var token = await localStorage.GetItemAsync<string>("token");
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await httpClient.GetStringAsync("IsCheckUpdateUser");
        Console.WriteLine(response);
        return Convert.ToBoolean(response);
    }

    public async Task UpdateUser(ProfileUserRequest profile)
    {
        Console.WriteLine(profile);
        var token = await localStorage.GetItemAsync<string>("token");
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var result = await httpClient.PostAsJsonAsync("UpdateUser", profile);
        Console.WriteLine(result);
    }

    public async Task Logout()
    {
    }
}