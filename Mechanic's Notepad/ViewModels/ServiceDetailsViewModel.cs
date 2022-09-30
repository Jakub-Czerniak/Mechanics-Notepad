using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mechanic_s_Notepad.Models;
using DataLibrary.Logic;


namespace Mechanic_s_Notepad.ViewModels
{
    public partial class ServiceDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        Service service;


    }
}
