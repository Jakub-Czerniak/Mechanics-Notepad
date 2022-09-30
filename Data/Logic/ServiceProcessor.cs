using DataLibrary.Models;
using DataLibrary.DataAccess;

namespace DataLibrary.Logic
{
    public class ServiceProcessor
    {
        public static List<ServiceModel> LoadCarSeviceHistory(int id)
        {
            return null;
        }

        public static int AddNewService(string shortDesc, string notes, decimal price, DateTime startDate, DateTime finishDate, string status, int carID, List<string> toDopoints)
        {
            ServiceModel data = new ServiceModel 
            { 
                ShortDesc = shortDesc,
                Notes = notes,
                Price = price,
                StartDate = startDate,
                FinishDate = finishDate,
                Status = status,
                CarID = carID,
            };
            List<ToDoPointModel> ToDoPoints = new List<ToDoPointModel>();
            foreach (string toDo in toDopoints)
                ToDoPoints.Add(new ToDoPointModel { ToDo = toDo, Status = "ToDo" });

            

            return 0;
        }

        public static int EditService()
        {
            return 0;
        }

    }
}
