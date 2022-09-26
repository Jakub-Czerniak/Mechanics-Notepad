using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataLibrary.Logic;
using Mechanic_s_Notepad.Models;


namespace Mechanic_s_Notepad.ViewModels
{
    public partial class AddNewCarViewModel : ObservableObject      
    {
        [ObservableProperty]
        Car car;
        [ObservableProperty]
        Color saveButtonTextColor;

        [RelayCommand]
        async void AddNewCar()
        {
            if(car != null & car.Make != "" & car.Model != "" & car.LicansePlateNumber != "" &
                car.Owner != "" & car.PhoneNumber != "")
            _ = CarProcessor.AddNewCar(car.Owner, car.PhoneNumber, car.LicansePlateNumber ,car.Make,car.Model,car.YearOfProduction,car.Engine, car.Generation);
            car = null;
            await Shell.Current.GoToAsync("../");
        }

        [RelayCommand]
        void TextChanged()
        {
            if (car.Make != "" & car.Model != "" & car.LicansePlateNumber != "" &
                car.Owner != "" & car.PhoneNumber != "")
            {
                SaveButtonTextColor = Brush.Black.Color;
            }
            else
            {
                SaveButtonTextColor = Brush.Gray.Color;
            }
        }

        public AddNewCarViewModel()
        {
            car = new Car();
            car.Make = car.Model = car.LicansePlateNumber = car.Owner = car.PhoneNumber = "";
            SaveButtonTextColor = Brush.Gray.Color;
        }
    }
}
