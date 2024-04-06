namespace SampleApp.Views;

public partial class LogInPage : ContentPage
{
	public LogInPage(LoginPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
	}
}