using DataLibrary.Models;
using DataLibrary.DataAccess;


namespace DataLibrary.Logic
{
    public class ServiceProcessor
    {
        public static List<ServiceModel> LoadCarSeviceHistory(int carID)
        {
            ServiceModel data = new ServiceModel { CarID = carID };
            string sql = "SELECT Service.ShortDesc, Service.Notes, Service.Price, Service.Status, Service.Date AS StartDate From Service WHERE CarID = @CarID";
            return SqliteDataAccess.LoadData(sql,data);
        }

        public static List<ToDoPointModel> LoadToDo(int serviceID)
        {
            ToDoPointModel data = new ToDoPointModel { ServiceID = serviceID};
            string sql = "SELECT ToDoPoint.Text AS ToDo, FROM ToDoPoints WHERE ServiceID = @ServiceID";
            return SqliteDataAccess.LoadData(sql,data);
        }

        public static void AddNewService(string shortDesc, string notes, decimal price, DateTime startDate, string status, int carID, List<string> toDopoints)
        {
            ServiceModel data = new ServiceModel 
            { 
                ShortDesc = shortDesc,
                Notes = notes,
                Price = (int)(price*10),
                StartDate = startDate.ToString(),
                Status = status,
                CarID = carID,
            };


            string sql1 = "INSERT INTO Service(ShortDesc, Notes, Price, CarID, Status, Date) VALUES (@ShortDesc, @Notes, @Price, @CarID, @Status ,@StartDate)";
            _ = SqliteDataAccess.SaveData(sql1, data);

            string sql2 = "SELECT Service.ID FROM Service WHERE ShortDesc = @ShortDesc AND Notes = @Notes AND Price = @Price AND CarID = @CarID AND Status = @Status AND Date = @StartDate";
            data = SqliteDataAccess.LoadData<ServiceModel>(sql2, data)[0];

             List<ToDoPointModel> ToDoPoints = new List<ToDoPointModel>();
            if (toDopoints != null)
                foreach (string toDo in toDopoints)
                    ToDoPoints.Add(new ToDoPointModel { ToDo = toDo, Status = "ToDo", ServiceID = data.ID });

            string sql3 = "INSERT INTO ToDoPoints(ServiceID, Text, Status) VALUES (@ServiceID, @ToDo, @Status)";
            foreach (ToDoPointModel toDo in ToDoPoints)
                SqliteDataAccess.SaveData(sql3, toDo);
        }

        public static int EditService()
        {
            return 0;
        }

    }
}
