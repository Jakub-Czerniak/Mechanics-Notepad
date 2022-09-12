using Mechanic_s_Notepad.ViewModels;

namespace Mechanic_s_Notepad.Views;

public partial class CarDetailsPage : ContentPage
{
	public CarDetailsPage()
	{
		InitializeComponent();
        BindingContext = new CarDetailsViewModel();

	}
}