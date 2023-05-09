using CreditAppWeb.Data.Http.Users.Requests;

namespace CreditAppWeb.Pages.Users;

public partial class Profile
{
    public bool IsSave = true;
    public ProfileUserRequest ProfileUser = new();


    public async void UpdateUser()
    {
        await usersHttp.UpdateUser(ProfileUser);
    }

    public void ChangeIsSave()
    {
        IsSave = !IsSave;
    }

    protected override async Task OnInitializedAsync()
    {
        ProfileUser = await usersHttp.GetUser();
    }
}