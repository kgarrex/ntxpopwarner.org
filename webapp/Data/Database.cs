using System;
using System.Data;
using System.IO;
using Npgsql;
//using Npgsql.EntityFrameworkCore.PostgreSQL;

//namespace ntxpw;

public class Database {
  private readonly NpgsqlConnection? conn;

  private static readonly string host = "ntxpopwarner-server.postgres.database.azure.com";
  //private static readonly string host = "privatelink.postgres.database.azure.com";
  private static readonly string username = "xvusccwxoc"; 
  private static readonly string password = "X$AxJxVfkLyrbf3h";
  //private static readonly string dbName = "postgres";
  private static readonly string dbName = "ntxpopwarner-database";
  private static readonly short port = 5432;
  private static readonly string connString = $"Server={host};Username={username};Password={password};Database={dbName};Port={port};SSLMode=Prefer";

  public Database() {
    try {
      this.conn = new NpgsqlConnection(connString);
      Console.WriteLine(connString);
      this.conn.Open();
    }
    catch(Exception ex) {
      Console.WriteLine($"Exception: {ex.Message}");
    }
  }

  public void AddRegistration() {
  
  }

  public void CreateTeams() {
    // 1. Get well-known path to queries
    string path = Directory.GetCurrentDirectory();
    using FileStream stream = new FileStream($"{path}\\create-teams.sql", FileMode.Open);
    using NpgsqlCommand cmd = new NpgsqlCommand(null, this.conn).FromStream(stream);
    int num = cmd.ExecuteNonQuery();
  }
}

public static class NpgsqlExtensions {
  public static NpgsqlCommand FromStream(this NpgsqlCommand cmd, Stream stream) {
    using StreamReader reader = new StreamReader(stream);
    cmd.CommandText = reader.ReadToEnd();
    cmd.CommandType = CommandType.Text;
    return cmd;
  }
}
