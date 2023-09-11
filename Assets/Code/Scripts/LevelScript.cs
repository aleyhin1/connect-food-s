using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    [SerializeField] private int _levelNumber;
    private string _goal1;
    private string _goal2;
    private string _goal3;
    private int _goal1Count;
    private int _goal2Count;
    private int _goal3Count;
    private int _moveCount;
    private int? _highestScore;
    private bool? _isPlayable;

    private void Start()
    {
        SetData();
    }

    private void SetData()
    {
        if (_levelNumber > 0)
        {
            IDbConnection dbConnection = DatabaseUtility.OpenConnection();
            IDbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = "SELECT * " +
                "FROM LevelData " +
                "WHERE LevelNumber = " + _levelNumber;
            IDataReader dataReader = dbCommand.ExecuteReader();

            while (dataReader.Read())
            {
                _goal1 = dataReader.GetString(1);
                _goal1Count = dataReader.GetInt32(2);
                _goal2 = dataReader.GetString(3);
                _goal2Count = dataReader.GetInt32(4);
                _goal3 = dataReader.GetString(5);
                _goal3Count = dataReader.GetInt32(6);
                _moveCount = dataReader.GetInt32(7);
                _isPlayable = dataReader.GetBoolean(8);
                _highestScore = dataReader.GetInt32(9);
            }
            DatabaseUtility.Close(dataReader, dbCommand, dbConnection);
        }
    }
}
