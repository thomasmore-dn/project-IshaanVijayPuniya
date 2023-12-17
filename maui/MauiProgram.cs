using Microsoft.Extensions.Logging;
using maui.Services;
using maui.ViewModels;

namespace maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<IDataService, DataService>();

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<SneakerViewPage>();
		builder.Services.AddTransient<AddSneakerPage>();

		builder.Services.AddTransient<MainPageVM>();
		builder.Services.AddTransient<SneakerDetailVM>();
		builder.Services.AddTransient<AddSneakerVM>();


#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
