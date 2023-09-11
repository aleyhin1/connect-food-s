using System.Data;
using Mono.Data.Sqlite;

public static class DatabaseUtility
{
    public static IDbConnection OpenConnection()
    {
        // Creates and opens a connection to the database
        const string connectionString = "URI=file:ConnectFoodsDB.db";
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
