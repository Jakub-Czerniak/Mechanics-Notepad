using CommunityToolkit.Mvvm.ComponentModel;
using Mechanic_s_Notepad.Models;
using System.Collections.ObjectModel;
using DataLibrary.Logic;
using CommunityToolkit.Mvvm.Input;
using Mechanic_s_Notepad.Views;

namespace Mechanic_s_Notepad.ViewModels
{
    public partial class CarListViewModel : ObservableObject
    {

        public ObservableCollection<Car> Cars { get; }
        public Command LoadCarsCommand { get; }
        public Command<Car> CarTapped { get; }


        public CarListViewModel()
        {
            Cars = new ObservableCollection<Car>();
            LoadCarsCommand = new Command(ExecuteLoadCarsCommand);
            CarTapped = new Command<Car>(OnCarSelected);
            ExecuteLoadCarsCommand();
        }
        
        async void OnCarSelected(Car obj)
        {
            var navigationParametr = new Dictionary<string, object>
            {
                {"Car", obj }
            };
            await Shell.Current.GoToAsync($"{nameof(CarDetailsPage)}", navigationParametr);
        }
        
        private void ExecuteLoadCarsCommand()
        {
            Cars.Clear();
            var cars = CarProcessor.LoadCars();
            if(cars.Count!=0)
                foreach (var car in cars)
                {
                    Cars.Add(new Car 
                    {
                        Id = car.ID,
                        LicansePlateNumber = car.LicensePlateNumber,
                        Make = car.Make,
                        Model = car.Model,
                        Engine = car.Engine,
                        YearOfProduction = car.YearOfProduction,
                        Owner = car.Owner,
                        Generation = car.Generation,
                    });
                }
        }

        [RelayCommand]
        async void AddButtonTap()
        {
            await Shell.Current.GoToAsync($"{nameof(AddCarPage)}");
        }
    }
}
