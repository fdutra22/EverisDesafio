
using Everis.Models;
using SQLite;
using System;
using System.IO;

namespace Everis.Data
{
    public class DataBase
    {
        public static SQLiteConnection db;
        public DataBase()
        {
            string dbPath = Path.Combine(
               Environment.GetFolderPath(Environment.SpecialFolder.Personal),
               "garagempark.db3");
             db = new SQLiteConnection(dbPath);
        }
        public void InitTables()
        {
           
            db.CreateTable<InscricaoModel>();
            db.CreateTable<EventoModel>();
        }
        
    }
}
