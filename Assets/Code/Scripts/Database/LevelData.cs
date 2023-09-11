using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class LevelData : MonoBehaviour
{
    private void Awake()
    {
        CreateTable();
        CreateLevel(1, "Banana", 5, "Water", 5, "Pumpkin", 5, 45);
        CreateLevel(2, "Apple", 7, "Pumpkin", 7, "Leaf", 7, 60);
    }

    private void CreateTable()
    {
        IDbConnection dbConnection = DatabaseUtility.OpenConnection();
        IDbCommand createTableCommand = dbConnection.CreateCommand();
        createTableCommand.CommandText =
            "CREATE TABLE IF NOT EXISTS LevelData " +
            "(LevelNumber INTEGER PRIMARY KEY, Goal1 TEXT, Goal1Count INT, Goal2 TEXT, Goal2Count INT, Goal3 TEXT, Goal3Count INT, " +
            "MoveCount INT, Playable BOOL DEFAULT false, HighestScore INT DEFAULT 0)";

        createTableCommand.ExecuteNonQuery();
        dbConnection.Close();
    }

    private void CreateLevel(int levelNumber, string goal1, int goal1Count, string goal2, int goal2Count, string goal3, int goal3Count,
        int moveCount)
    {
        IDbConnection dbConnection = DatabaseUtility.OpenConnection();
        IDbCommand createLevelCommand = dbConnection.CreateCommand();
        createLevelCommand.CommandText = "INSERT OR REPLACE INTO LevelData (LevelNumber, Goal1, Goal1Count, Goal2, Goal2Count, Goal3, " +
            "Goal3Count, MoveCount)" +
            "VALUES(@LevelNumber, @Goal1, @Goal1Count, @Goal2, @Goal2Count, @Goal3,@Goal3Count, @MoveCount)";
        createLevelCommand.Parameters.Add(new SqliteParameter("@LevelNumber", levelNumber));
        createLevelCommand.Parameters.Add(new SqliteParameter("@Goal1", goal1));
        createLevelCommand.Parameters.Add(new SqliteParameter("@Goal1Count", goal1Count));
        createLevelCommand.Parameters.Add(new SqliteParameter("@Goal2", goal2));
        createLevelCommand.Parameters.Add(new SqliteParameter("@Goal2Count", goal2Count));
        createLevelCommand.Parameters.Add(new SqliteParameter("@Goal3", goal3));
        createLevelCommand.Parameters.Add(new SqliteParameter("@Goal3Count", goal3Count));
        createLevelCommand.Parameters.Add(new SqliteParameter("@MoveCount", moveCount));
        createLevelCommand.ExecuteNonQuery();
        dbConnection.Close();
    }
}