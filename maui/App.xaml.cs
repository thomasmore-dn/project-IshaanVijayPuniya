namespace maui;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

	[STAThread]
	static void Main()
	{
	}
}
