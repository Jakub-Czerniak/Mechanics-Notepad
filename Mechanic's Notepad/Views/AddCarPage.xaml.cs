
using Mechanic_s_Notepad.ViewModels;

namespace Mechanic_s_Notepad.Views;
public partial class AddCarPage : ContentPage
{
    public AddCarPage()
    {
        InitializeComponent();
        BindingContext = new AddNewCarViewModel();
    }
}