
using SQLite;
using FormsAssistControl.Storage.Interfaces;
using System;
using System.IO;
using Xamarin.Forms;
using FormsAssistControl.Droid.Storage.Implementations;

[assembly:Dependency(typeof(SQLiteDroid))]
namespace FormsAssistControl.Droid.Storage.Implementations
{
    class SQLiteDroid : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            SQLitePCL.Batteries.Init();
            var sqliteFilename = "TodoSQLite.db3";
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath,sqliteFilename);

            //Create the Connection
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}