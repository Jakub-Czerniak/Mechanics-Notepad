using CommunityToolkit.Mvvm.ComponentModel;
using Mechanic_s_Notepad.Models;
using System.Collections.ObjectModel;
using DataLibrary.Logic;

namespace Mechanic_s_Notepad.ViewModels
{
    public partial class CarListViewModel : ObservableObject
    {
        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public ObservableCollection<Car> Cars { get; }
        public Command LoadCarsCommand { get; }
        public Command<Car> CarTapped { get; }


        public CarListViewModel()
        {
            Title = "Mechanic's Notepad";
            Cars = new ObservableCollection<Car>();
            LoadCarsCommand = new Command(ExecuteLoadCarsCommand);
            CarTapped = new Command<Car>(OnCarSelected);
            ExecuteLoadCarsCommand();
        }

        private void OnCarSelected(Car obj)
        {
            throw new NotImplementedException();
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
    }
}
