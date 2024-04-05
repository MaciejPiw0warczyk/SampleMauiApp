namespace SampleApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("FontAwesome6FreeBrands.otf", "FABrands");
				fonts.AddFont("FontAwesome6FreeRegular.otf", "FARegular");
				fonts.AddFont("FontAwesome6FreeSolid.otf", "FASolid");
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        //TOSEE: Każda strona musi zostać zarejestrowana jako singleton(Zawsze będzie podawana ta sama instancja) lub transient(za każdyn razem będzie podawana kompletnie nowa) https://grantwinney.com/difference-between-singleton-scoped-transient/ 
		builder.Services.AddSingleton<SamplePage>();
        builder.Services.AddSingleton<SampleViewModel>();

		builder.Services.AddSingleton<BlankPage>();
		builder.Services.AddSingleton<BlankViewModel>();

        builder.Services.AddSingleton<TaskListPage>();
        builder.Services.AddSingleton<TaskListViewModel>();

		builder.Services.AddTransient<SampleDataService>();
		builder.Services.AddTransient<ListDetailDetailViewModel>();
		builder.Services.AddTransient<ListDetailDetailPage>();

		builder.Services.AddSingleton<ListDetailViewModel>();

		builder.Services.AddSingleton<ListDetailPage>();

		return builder.Build();
	}
}
