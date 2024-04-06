using Firebase.Auth;
using Firebase.Auth.Providers;
using SampleApp.Features.SignUp;
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

        builder.Services.AddTransient<SignUpViewModel>();
        builder.Services.AddTransient<SignUpPage>();

        builder.Services.AddTransient<SignUpFormView>();
        builder.Services.AddTransient<SignUpFormViewModel>();

        //firebase stuff

        builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig(){
            ApiKey= "AIzaSyCXvi1BwChMn3U41FpEgUKTdH0jel5F0Q8",
            AuthDomain= "sampleapp-1dd2a.firebaseapp.com",
            Providers = [new EmailProvider()]
        }));

		return builder.Build();
	}
}
