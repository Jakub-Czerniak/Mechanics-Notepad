using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mechanic_s_Notepad.Models;
using DataLibrary.Logic;
using Mechanic_s_Notepad.Views;
using System.Collections.ObjectModel;

namespace Mechanic_s_Notepad.ViewModels
{
    [QueryProperty("Car","Car")]
    public partial class CarDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        Car car;

        public ObservableCollection<Service> Services { get; }

        [RelayCommand]
        async void AddButtonTap()
        {
            await Shell.Current.GoToAsync($"{nameof(AddServicePage)}?CarID={Car.Id}");
        }

        [RelayCommand]
        async void ServiceTap(Service obj)
        {
            await Shell.Current.GoToAsync($"{nameof(ServiceDetailsPage)}?ServiceID={obj.ID}");
        }


        public CarDetailsViewModel()
        {
            Services = new ObservableCollection<Service>();
        }
    }
}
