using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mechanic_s_Notepad.Models;
using DataLibrary.Logic;


namespace Mechanic_s_Notepad.ViewModels
{
    [QueryProperty("CarID", "CarID")]
    public partial class AddNewServiceViewModel : ObservableObject
    {
        [ObservableProperty]
        int carID;
        [ObservableProperty]
        Service service;
        [ObservableProperty]
        Color saveButtonColor;

        [RelayCommand]
        async void AddNewService()
        {
            if(service.ShortDesc == "")
            ServiceProcessor.AddNewService(service.ShortDesc, service.Notes, service.Price, service.StartDate, service.FinishDate, service.Status, service.CarID, service.ToDoPoints);
            await Shell.Current.GoToAsync("../");
        }

        [RelayCommand]
        void AddNewToDo()
        {

        }

        public AddNewServiceViewModel()
        {
            service = new Service();
            service.ShortDesc = service.Notes = "";
            service.Status = "Started";
            service.CarID = CarID;
        }
    }
}
