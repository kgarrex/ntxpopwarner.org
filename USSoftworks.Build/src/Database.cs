using Microsoft.Data.Sqlite;
using System;
using System.Data.SqlClient;

public class Database : Microsoft.Build.Utilities.Task
{
  private readonly string connectionString = "Data Source=build.db;";
  public override bool Execute()
  {
    try
    {
      using (SqliteConnection connection = new SqliteConnection(connectionString))
      {
        connection.Open();

        string sql =
        @"CREATE TABLE IF NOT EXISTS Users(
          first_name TEXT NOT NULL,
          last_name TEXT NOT NULL,
          email TEXT NOT NULL UNIQUE
        )";

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = sql;
        int result = command.ExecuteNonQuery();
      }
    }
    catch(Exception ex)
    {
      Log.LogErrorFromException(ex);
    }
    return !Log.HasLoggedErrors;
  }
}
