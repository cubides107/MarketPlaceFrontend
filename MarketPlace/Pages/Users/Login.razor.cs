using System.Text.Json;
using CreditAppWeb.Data.Http.Users.Requests;
using Radzen;
using Exception = CreditAppWeb.Shared.Models.Exception;

namespace CreditAppWeb.Pages.Users;

public partial class Login
{
    private string Error = string.Empty;
    private bool isVisible = false;

    private LoginRequest loginRequest = new();

    private async Task HandleLogin()
    {
        isVisible = false;
        var token = await usersHttp.LoginUser(loginRequest);
        Console.WriteLine(token);

        if (token.Contains("statusCode"))
        {
            var exception = JsonSerializer.Deserialize<Exception>(token);
            Error = exception.Message;
            isVisible = true;
            return;
        }

        await LocalStorage.SetItemAsync("token", token);
        await AuthStateProvider.GetAuthenticationStateAsync();

        NavigationManager.NavigateTo("../");
    }

    private void ShowNotification(NotificationMessage message)
    {
        NotificationService.Notify(message);
    }
}