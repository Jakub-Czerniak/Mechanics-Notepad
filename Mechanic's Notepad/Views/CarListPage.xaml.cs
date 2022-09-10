using Mechanic_s_Notepad.ViewModels;

namespace Mechanic_s_Notepad.Views;

public partial class CarListPage : ContentPage
{
	public CarListPage()
	{
		InitializeComponent();
		BindingContext = new CarListViewModel();
		
	}
}