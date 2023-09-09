using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class LevelData : MonoBehaviour
{
    private void Start()
    {
        CreateTable();
        CreateLevel(1, "test", 2, "test", 3, "test", 4, 5, false, 6);
    }

    private IDbConnection OpenConnection()
    {
        // Creates and opens a connection to the database
        const string connectionString = "URI=file:ConnectFoodsDB.db";
        IDbConnection dbConnection = new SqliteConnection(connectionString);
        dbConnection.Open();
        return dbConnection;
    }

    private void CreateTable()
    {
        IDbConnection dbConnection = OpenConnection();
        IDbCommand createTableCommand = dbConnection.CreateCommand();
        createTableCommand.CommandText =
            "CREATE TABLE IF NOT EXISTS LevelData " +
            "(LevelNumber INTEGER PRIMARY KEY, Goal1 TEXT, Goal1Count INT, Goal2 TEXT, Goal2Count INT, Goal3 TEXT, Goal3Count INT, " +
            "MoveCount INT, Playable BOOL, HighestScore INT)";

        createTableCommand.ExecuteNonQuery();
        dbConnection.Close();
    }

    private void CreateLevel(int levelNumber, string goal1, int goal1Count, string goal2, int goal2Count, string goal3, int goal3Count,
        int moveCount, bool playable, int highestScore)
    {
        IDbConnection dbConnection = OpenConnection();
        IDbCommand createLevelCommand = dbConnection.CreateCommand();
        createLevelCommand.CommandText = "INSERT INTO LevelData (LevelNumber, Goal1, Goal1Count, Goal2, Goal2Count, Goal3, " +
            "Goal3Count, MoveCount, Playable, HighestScore)" +
            "VALUES(@LevelNumber, @Goal1, @Goal1Count, @Goal2, @Goal2Count, @Goal3,@Goal3Count, @MoveCount, @Playable, @HighestScore)";
        createLevelCommand.Parameters.Add(new SqliteParameter("@LevelNumber", levelNumber));
        createLevelCommand.Parameters.Add(new SqliteParameter("@Goal1", goal1));
        createLevelCommand.Parameters.Add(new SqliteParameter("@Goal1Count", goal1Count));
        createLevelCommand.Parameters.Add(new SqliteParameter("@Goal2", goal2));
        createLevelCommand.Parameters.Add(new SqliteParameter("@Goal2Count", goal2Count));
        createLevelCommand.Parameters.Add(new SqliteParameter("@Goal3", goal3));
        createLevelCommand.Parameters.Add(new SqliteParameter("@Goal3Count", goal3Count));
        createLevelCommand.Parameters.Add(new SqliteParameter("@MoveCount", moveCount));
        createLevelCommand.Parameters.Add(new SqliteParameter("@Playable", playable));
        createLevelCommand.Parameters.Add(new SqliteParameter("@HighestScore", highestScore));
        createLevelCommand.ExecuteNonQuery();
        dbConnection.Close();
    }
}