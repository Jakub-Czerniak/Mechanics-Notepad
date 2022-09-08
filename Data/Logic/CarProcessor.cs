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
            string sql = @"SELECT Car.ID, Car.LicansePlateNumber, Make.Name AS Make, Customer.Name AS Owner, Model.Name AS Model, YearOfProduction.Year AS YearOfProduction,
                            Car.Generation, Engine.Name AS Engine FROM Car 
                            INNER JOIN  Make ON Car.MakeID = Make.ID 
                            INNER JOIN Customer ON Car.CustomerID = Customer.ID
                            INNER JOIN Model ON Car.ModelID = Model.ID 
                            INNER JOIN YearOfProduction ON Car.YearOfProductionID = YearOfProduction.ID
                            INNER JOIN Engine ON Car.EngineID = Engine.ID
                            ORDER BY Car.AccessDate DESC
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

        public static int AddNewCar(string owner, string make, string model, int year, string generation, string engine)
        {
            CarModel data = new CarModel
            {
                Owner = owner,
                Make = make,
                Model = model,
                YearOfProduction = year,
                Generation = generation,
                Engine = engine,
            };

            string sql = @"";

            return SqliteDataAccess.SaveData<CarModel>(sql, data);
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
