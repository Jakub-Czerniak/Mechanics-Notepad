using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mechanic_s_Notepad.Models;
using DataLibrary.Logic;

namespace Mechanic_s_Notepad.ViewModels
{
    partial class CarDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        Car car;

        [RelayCommand]
        void LoadCarDetails(int id)
        {
            var obj = CarProcessor.LoadCarDetails(id);
            car = new Car();
            car.Id = obj[0].ID;
            car.Make = obj[0].Make;
            car.Model = obj[0].Model;
            car.Engine = obj[0].Engine;
            car.Owner = obj[0].Owner;
            car.Generation = obj[0].Generation;
            car.LicansePlateNumber = obj[0].LicensePlateNumber;
            car.YearOfProduction = obj[0].YearOfProduction;
            car.Notes = obj[0].Notes;
        }

        CarDetailsViewModel()
        {

        }
    }
}
