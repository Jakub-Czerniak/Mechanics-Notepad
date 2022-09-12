using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mechanic_s_Notepad.Models;
using DataLibrary.Logic;

namespace Mechanic_s_Notepad.ViewModels
{
    public partial class CarDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        Car car;
        [ObservableProperty]
        List<Service> services;

        [RelayCommand]
        void LoadCarDetails(int id)
        {
            var carObj = CarProcessor.LoadCarDetails(id);
            car = new Car();
            car.Id = carObj[0].ID;
            car.Make = carObj[0].Make;
            car.Model = carObj[0].Model;
            car.Engine = carObj[0].Engine;
            car.Owner = carObj[0].Owner;
            car.Generation = carObj[0].Generation;
            car.LicansePlateNumber = carObj[0].LicensePlateNumber;
            car.YearOfProduction = carObj[0].YearOfProduction;
            car.Notes = carObj[0].Notes;
            var serviceObj = ServiceProcessor.LoadCarSeviceHistory(id);
            services.Clear();
            if (services.Count != 0)
                foreach (var service in serviceObj)
                    services.Add(new Service
                    {
                        Id = service.ID,
                        ShortDesc = service.ShortDesc,
                        Status = service.Status,
                        Date = service.Date,
                    });

        }

        public CarDetailsViewModel()
        {
            services = new List<Service>();
        }
    }
}
