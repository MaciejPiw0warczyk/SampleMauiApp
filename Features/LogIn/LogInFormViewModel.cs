using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
using Firebase.Auth;

namespace SampleApp.Features.LogIn;
public partial class LogInFormViewModel:BaseViewModel
{
    private readonly FirebaseAuthClient _authClient;

    [ObservableProperty]
    public string email = string.Empty;
    [ObservableProperty]
    public string password = string.Empty;

    public LogInFormViewModel(FirebaseAuthClient authClient)
    {
        _authClient = authClient;
    }

    [RelayCommand]
    public async Task Login()
    {
        try
        {
            await _authClient.SignInWithEmailAndPasswordAsync(Email, Password);

            await Toast.Make($"Logged in socesfullt! Hello {_authClient.User.Uid}").Show();

            Shell.Current.SendBackButtonPressed();
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Login Error", ex.Message, "ok");
            //await Toast.Make("Login unsuccesfull, try again later.").Show();
        }
    }

}
