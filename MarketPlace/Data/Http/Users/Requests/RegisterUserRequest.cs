namespace CreditAppWeb.Data.Http.Users.Requests;

public class RegisterUserRequest
{
    public string Names { get; set; }

    public string LastNames { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}