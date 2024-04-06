using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Firebase.Auth;

namespace SampleApp.Features.SignUp;
public partial class SignUpFormViewModel : BaseViewModel
{
    private readonly FirebaseAuthClient _authClient;

    [ObservableProperty]
    public string email = string.Empty;

    [ObservableProperty]
    public string password = string.Empty;

    [ObservableProperty]
    public string confirmPassword = string.Empty;

    public SignUpFormViewModel(FirebaseAuthClient authClient)
    {
        _authClient = authClient;
    }

    [RelayCommand]
    public async Task SignUpAsync(FirebaseAuthClient client)
    {
        if (Password != ConfirmPassword) { await Toast.Make("Password and confirm password values do not match").Show(); return; }

        try
        {
            await _authClient.CreateUserWithEmailAndPasswordAsync(Email, Password);

            await Toast.Make("Succesfullt registrated!! Chceck your Email for activation link", ToastDuration.Long, 18).Show();
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Failed to sign up. Please try again later.", "Ok");
        }
    }
}
