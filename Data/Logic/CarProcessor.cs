using DataLibrary.Models;
using DataLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Logic
{
    public class CarProcessor
    {
        public static List<CarModel> LoadCars()
        {
            string sql = @"SELECT Car.ID, Car.LicensePlateNumber, Make.Name AS Make, Customer.Name AS Owner, Model.Name AS Model, Car.YearOfProduction AS YearOfProduction,
                            Car.Generation, Engine.Name AS Engine FROM Car 
                            INNER JOIN  Make ON Car.MakeID = Make.ID 
                            INNER JOIN Customer ON Car.CustomerID = Customer.ID
                            INNER JOIN Model ON Car.ModelID = Model.ID 
                            INNER JOIN Engine ON Car.EngineID = Engine.ID
                            ORDER BY Car.DateAccessed DESC
                            ";
            
            return SqliteDataAccess.LoadData<CarModel>(sql);
        }

        public static List<CarModel> LoadCarDetails(int id)
        {
            CarModel data = new CarModel
            {
                ID = id
            };

            string sql = @"SELECT * FROM Car WHERE Car.ID = ID INNERJOIN ON Car.MakeID = Make.ID ...";

            return SqliteDataAccess.LoadData<CarModel>(sql, data);
        }

        public static int EditCarDetails(int id, string owner, string make, string model, int year, string generation, string engine, string notes)
        {
            CarModel data = new CarModel
            {
                ID=id,
                Owner = owner,
                Make = make,
                Model = model,
                YearOfProduction = year,
                Generation = generation,
                Engine = engine,
                Notes = notes
            };

            string sql = @"";

            return SqliteDataAccess.SaveData<CarModel>(sql, data);
        }

        public static int AddNewCar(string owner, string phoneNumber, string licenseNumber ,string make, string model, int year, string engine, string generation)
        {
            CarModel data = new CarModel
            {
                Owner = owner,
                PhoneNumber = phoneNumber,
                LicensePlateNumber = licenseNumber,
                Make = make,
                Model = model,
                YearOfProduction = year,
                Engine = engine,
                Generation = generation,
            };

            string sql1 = "INSERT INTO Customer(Name, PhoneNumber) VALUES(@Owner, @PhoneNumber) ON CONFLICT(PhoneNumber) DO UPDATE SET Name = excluded.Name";

            string sql2 = "INSERT INTO Make(Name) VALUES(@Make) ON CONFLICT(Name) DO NOTHING";

            string sql3 = @"INSERT INTO Model(MakeID, Name)
                            VALUES ((SELECT ID FROM Make WHERE Name = @Make), @Model)
                            ON CONFLICT(Name) DO NOTHING";
            string sql4 = @"INSERT INTO Engine(Name)
                            VALUES (@Engine)
                            ON CONFLICT(Name) DO NOTHING";
            string sql5 = @"INSERT INTO Car(LicensePlateNumber, MakeID, ModelID, YearOfProduction, EngineID, Generation, CustomerID, DateAccessed)
                            VALUES(@LicensePlateNumber, (SELECT ID FROM Make WHERE Name = @Make), (SELECT ID FROM Model WHERE Name = @Model), @YearOfProduction, (SELECT ID FROM Engine WHERE Name = @Engine), @Generation, (SELECT ID FROM Customer WHERE PhoneNumber = @PhoneNumber), strftime('%s','now'))
                            ON CONFLICT(LicensePlateNumber) DO UPDATE SET
                            MakeID = excluded.MakeID,
                            ModelID = excluded.ModelID,
                            YearOfProduction = excluded.YearOfProduction,
                            EngineID = excluded.EngineID,
                            Generation = excluded.Generation,
                            CustomerID = excluded.CustomerID,
                            DateAccessed = excluded.DateAccessed";
            SqliteDataAccess.SaveData<CarModel>(sql1, data);
            SqliteDataAccess.SaveData<CarModel>(sql2, data);
            SqliteDataAccess.SaveData<CarModel>(sql3, data);
            SqliteDataAccess.SaveData<CarModel>(sql4, data);
            return SqliteDataAccess.SaveData<CarModel>(sql5, data);
        }

        public static List<CarModel> SearchForOwner(string owner) //looking for owner after some letter is written in search bar
        {
            CarModel data = new CarModel
            {
                Owner = owner,
            };

            string sql = @"";

            return SqliteDataAccess.LoadData<CarModel>(sql, data);
        }

        public static List<CarModel> SearchForCar(string owner , string licensePlateNumber, string make, string model, int year, string generation, string engine) 
        {
            CarModel data = new CarModel
            {
                Owner = owner,
                LicensePlateNumber = licensePlateNumber,
                Make = make,
                Model = model,
                YearOfProduction = year,
                Generation = generation,
                Engine = engine,
            };

        string sql = @"";

            return SqliteDataAccess.LoadData<CarModel>(sql, data);
        }
    }
}
