using CommunityToolkit.Maui.Alerts;

namespace SampleApp.ViewModels;
public partial class TaskListViewModel : BaseViewModel
{
    readonly SampleDataService dataService;


    [ObservableProperty]
    ObservableCollection<SampleItem> tasks = [];

    public TaskListViewModel(SampleDataService service)
    {
        dataService = service;
    }

    [RelayCommand]
    private async Task OnRefresing()
    {
        IsRefreshing = true;

        try
        {
            await LoadDataAsync();
        }
        finally
        {
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    public async Task SaveDataAsync()
    {
        var succes = await dataService.SaveTasks(Tasks);

        if (succes)
        {
            await Toast.Make("Zadania zapisano pomyślnie").Show();
        }
        else
        {
            await Toast.Make("Nie zapisano! Podczas zapisu napotkano problem").Show();
        }
    }

    [RelayCommand]
    public Task AddTask()
    {
        Tasks.Add(new SampleItem());
        return Task.CompletedTask;
    }

    public async Task LoadDataAsync()
    {
        Tasks.Clear();
        var data = await dataService.GetTasks();
        foreach (var task in data) { Tasks.Add(task); }
    }
}
