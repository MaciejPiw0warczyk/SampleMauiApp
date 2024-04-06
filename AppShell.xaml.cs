namespace SampleApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        //TOSEE: Jeśli do strony można nawigować poza Shell to trzeba ją tu zarejestrować do Routing
		Routing.RegisterRoute(nameof(ListDetailDetailPage), typeof(ListDetailDetailPage));
        Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
	}
}
