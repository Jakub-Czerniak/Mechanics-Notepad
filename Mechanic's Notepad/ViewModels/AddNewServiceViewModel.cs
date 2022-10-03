using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mechanic_s_Notepad.Models;
using DataLibrary.Logic;
using System.Collections.ObjectModel;
using Mechanic_s_Notepad.Views;
using Microsoft.Maui.Graphics.Text;

namespace Mechanic_s_Notepad.ViewModels
{
    [QueryProperty("CarID", "CarID")]
    public partial class AddNewServiceViewModel : ObservableObject
    {
        [ObservableProperty]
        string carID;
        [ObservableProperty]
        Service service;
        [ObservableProperty]
        string toDoText;
        [ObservableProperty]
        public ObservableCollection<string> toDoList;
        [ObservableProperty]
        public TimeSpan timeOfTheDay;

        [RelayCommand]
        void AddNewService()
        { 
            if (service != null & service.ShortDesc != "")
            {
                service.CarID = Int32.Parse(CarID);
                if (service.StartDate.CompareTo(DateTime.Now) > 0)
                    service.Status = "Planned";
                else
                    service.Status = "Started";
                service.StartDate += timeOfTheDay;
                foreach (string toDo in toDoList)
                    service.ToDoPoints.Add(toDo); 
                ServiceProcessor.AddNewService(service.ShortDesc, service.Notes, service.Price, service.StartDate, service.Status, service.CarID, service.ToDoPoints);
                service = null;
            }
            Shell.Current.GoToAsync(nameof(CarListPage));
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
            service.StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,0,0,0,0);
            ToDoList = new ObservableCollection<string>();
            service.ShortDesc = service.Notes = "";
            service.Status = "Started";
            service.ToDoPoints = new List<string>();
        }
    }
}
