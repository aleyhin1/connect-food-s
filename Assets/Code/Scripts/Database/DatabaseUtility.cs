using System.Data;
using System.IO;
using Mono.Data.Sqlite;
using UnityEngine;

public static class DatabaseUtility
{
    public static IDbConnection OpenConnection()
    {
        // Creates and opens a connection to the database
        string connectionString = "URI=file:" + Path.Combine(Application.persistentDataPath, "ConnectFoodsDB.db");
        IDbConnection dbConnection = new SqliteConnection(connectionString);
        dbConnection.Open();
        return dbConnection;
    }

    public static void Close(IDataReader dataReader, IDbCommand dbCommand, IDbConnection dbConnection)
    {
        dataReader.Dispose();
        dbConnection.Dispose();
        dbConnection.Close();
    }
}
