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
        var result = await dataService.SaveTasks(Tasks);
        
        if (result.IsSuccesfull)
        {
            await Toast.Make("Tasks Saved succesfully!").Show();
        }
        else
        {
            await Toast.Make($"Task not saved! Encoutered an error {result.Exception.Message}").Show();
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
