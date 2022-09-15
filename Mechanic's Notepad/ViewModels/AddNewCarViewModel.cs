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
        void AddNewCar()
        {
            if(car != null)
            _ = CarProcessor.AddNewCar(car.Owner, car.PhoneNumber, car.LicansePlateNumber ,car.Make,car.Model,car.YearOfProduction,car.Engine, car.Generation);
            car = null;
        }

        [RelayCommand]
        void TextChanged()
        {
            if (car.Make.ToString() != "" & car.Model.ToString() != "" & car.LicansePlateNumber.ToString() != "" &
                car.Owner.ToString() != "")
            {
                saveButtonTextColor = Brush.White.Color;
            }
            else
            {
                saveButtonTextColor = Brush.Gray.Color;
            }
        }

        AddNewCarViewModel()
        {
            car = new Car();
            saveButtonTextColor = Brush.Gray.Color;
        }
    }
}
