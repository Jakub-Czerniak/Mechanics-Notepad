using Dapper;
using Microsoft.Maui.Media;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DataAccess
{
    public class SqliteDataAccess
    {
        private static string LoadConnectionString()
        {
            string dbPath = $"Data source = C:\\Users\\Kuba\\source\\repos\\Mechanic's Notepad\\Mechanic's Notepad\\MechNoteDB.db";
            //var dbPath = Path.Combine("Data source =", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MechNoteDB.db");
            return dbPath; 
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                return cnn.Query<T>(sql).ToList();
        }

        public static List<T> LoadData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()) )
                return cnn.Query<T>(sql,data).ToList();
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                return cnn.Execute(sql, data);
        }
    }
}
