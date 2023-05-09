using System.Text.Json;
using CreditAppWeb.Data.Http.Users.Requests;
using Exception = CreditAppWeb.Shared.Models.Exception;

namespace CreditAppWeb.Pages.Users;

public partial class Register
{
    private string Error = string.Empty;
    private bool IsVisible;

    public RegisterUserRequest User = new();

    private async Task RegisterUser()
    {
        var response = await usersHttp.RegisterUser(User);

        if (response.Contains("statusCode"))
        {
            var exception = JsonSerializer.Deserialize<Exception>(response);
            Error = exception.Message;
            Console.WriteLine(exception.Message);
            IsVisible = true;
            return;
        }

        NavigationManager.NavigateTo("login");
    }
}