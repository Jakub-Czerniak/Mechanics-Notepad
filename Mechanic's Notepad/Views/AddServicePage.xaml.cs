using Mechanic_s_Notepad.ViewModels;

namespace Mechanic_s_Notepad.Views;

public partial class AddServicePage : ContentPage
{
	public AddServicePage()
	{
		InitializeComponent();
		BindingContext = new AddNewServiceViewModel();
	}
}