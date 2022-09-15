using Mechanic_s_Notepad.Views;

namespace Mechanic_s_Notepad;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AddCarPage), typeof(AddCarPage));
	}
}
