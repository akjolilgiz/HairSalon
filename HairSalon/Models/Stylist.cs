using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;
using System;

namespace HairSalon.Models
{
  public class Stylist
  {
    public int id {get; set; }
    public string name {get; set; }

    public Stylist(string newName, int Id = 0)
      {
        id = Id;
        name = newName;
      }
    public static List<Stylist> GetAll()
      {
        List<Stylist> allStylists = new List<Stylist> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM stylists;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int stylistId = rdr.GetInt32(0);
          string stylistName = rdr.GetString(1);
          Stylist newStylist = new Stylist(stylistName, stylistId);
          allStylists.Add(newStylist);
        }
        conn.Close();
        if (conn !=null)
        {
          conn.Dispose();
        }
        return allStylists;
      }
    public void Save()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO stylists (name) VALUES (@StylistName);";

        MySqlParameter newName = new MySqlParameter();
        newName.ParameterName = "@StylistName";
        newName.Value = this.name;
        cmd.Parameters.Add(newName);


        cmd.ExecuteNonQuery();
        id = (int) cmd.LastInsertedId;

        conn.Close();
        if (conn !=null)
        {
          conn.Dispose();
        }
      }
  }
}
