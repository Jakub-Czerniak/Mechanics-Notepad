using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mechanic_s_Notepad.Models;
using DataLibrary.Logic;
using System.Collections.ObjectModel;

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
        string toDoText;
        [ObservableProperty]
        public ObservableCollection<string> toDoList;

        [RelayCommand]
        async void AddNewService()
        {
            if(service.ShortDesc == "")
            ServiceProcessor.AddNewService(service.ShortDesc, service.Notes, service.Price, service.StartDate, service.Status, service.CarID, service.ToDoPoints);
            service = null;
            await Shell.Current.GoToAsync("../");
        }

        [RelayCommand]
        void AddNewToDo()
        {
            if (string.IsNullOrWhiteSpace(ToDoText))
                return;

            ToDoList.Add(ToDoText);
            ToDoText = string.Empty;
        }

        [RelayCommand]
        void DeleteToDo(string s)
        {
            if(ToDoList.Contains(s))
                ToDoList.Remove(s);
        }

        public AddNewServiceViewModel()
        {
            service = new Service();
            ToDoList = new ObservableCollection<string>();
            service.ShortDesc = service.Notes = "";
            service.Status = "Started";
            service.CarID = CarID;
        }
    }
}
