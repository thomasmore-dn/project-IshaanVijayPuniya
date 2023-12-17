using maui.ViewModels;
using maui.Services;

namespace maui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(SneakerViewPage), typeof(SneakerViewPage));
		Routing.RegisterRoute(nameof(AddSneakerPage), typeof(AddSneakerPage));
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        //In the Shell subclass constructor, or any other location that runs before a route is invoked,
		// additional routes can be explicitly registered for any detail pages that aren't represented in
		// the Shell visual hierarchy. This is accomplished with the Routing.RegisterRoute method.
		// As described in the lecture I use shell to navigate between pages.
		
		
	}
}
