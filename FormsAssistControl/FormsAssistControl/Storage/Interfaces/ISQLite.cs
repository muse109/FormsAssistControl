using SQLite;
using System;

namespace FormsAssistControl.Storage.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    } 
   
}
