namespace maui;
using maui.Services;
using maui.Models;
using maui.ViewModels;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageVM viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		System.Net.ServicePointManager.SecurityProtocol =
                System.Net.SecurityProtocolType.Tls12| System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls;
        // setting this up so the app can parse tls packet headers correctly.				
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		await (BindingContext as MainPageVM).GetSneakersAsync();
	}
}

