using Mechanic_s_Notepad.Views;

namespace Mechanic_s_Notepad;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AddCarPage), typeof(AddCarPage));
		Routing.RegisterRoute(nameof(CarListPage), typeof(CarListPage));
		Routing.RegisterRoute(nameof(CarDetailsPage), typeof(CarDetailsPage));
		Routing.RegisterRoute(nameof(AddServicePage), typeof(AddServicePage));
		Routing.RegisterRoute(nameof(ServiceDetailsPage), typeof(ServiceDetailsPage));
	}
}
