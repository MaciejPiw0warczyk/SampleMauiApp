using SampleApp.ViewModels;

namespace SampleApp.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    bool isRefreshing;

    [RelayCommand]
    private async Task GoToAsync(string route)
    {
        await Shell.Current.GoToAsync(route);
    }
}
