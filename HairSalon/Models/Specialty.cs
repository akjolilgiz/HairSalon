using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;
using System;

namespace HairSalon.Models
{
  public class Specialty
  {
    public int id {get; set; }
    public string description {get; set; }

    public Specialty(string newDescription, int Id = 0)
      {
        id = Id;
        description = newDescription;
      }
      
    public static List<Specialty> GetAll()
      {
        List<Specialty> allSpecialties = new List<Specialty> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM specialties;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int specialtyId = rdr.GetInt32(0);
          string specialtyDescription = rdr.GetString(1);
          Specialty newSpecialty = new Specialty(specialtyDescription, specialtyId);
          allSpecialties.Add(newSpecialty);
        }
        conn.Close();
        if (conn !=null)
        {
          conn.Dispose();
        }
        return allSpecialties;
      }
    public void Save()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO specialties (description) VALUES (@specialtyDescription);";

        cmd.Parameters.AddWithValue("@specialtyDescription", this.description);


        cmd.ExecuteNonQuery();
        id = (int) cmd.LastInsertedId;

        conn.Close();
        if (conn !=null)
        {
          conn.Dispose();
        }
      }
    public static Specialty Find(int id)
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM specialties where id = (@searchId);";
        cmd.Parameters.AddWithValue("@searchId", id);


        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        int specialtyId = 0;
        string specialtyDescription = "";
        while(rdr.Read())
        {
          specialtyId = rdr.GetInt32(0);
          specialtyDescription = rdr.GetString(1);
        }
        Specialty foundSpecialty = new Specialty(specialtyDescription, specialtyId);
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return foundSpecialty;
      }

    public static void DeleteAll()
       {
         MySqlConnection conn = DB.Connection();
         conn.Open();

         var cmd = conn.CreateCommand() as MySqlCommand;
         cmd.CommandText = @"DELETE FROM specialties;";

         cmd.ExecuteNonQuery();

         conn.Close();
         if (conn != null)
         {
             conn.Dispose();
         }
       }
    public override bool Equals(System.Object otherSpecialty)
       {
         if (!(otherSpecialty is Specialty))
         {
           return false;
         }
         else
         {

           Specialty newSpecialty = (Specialty) otherSpecialty;
           bool idEquality = (this.id == newSpecialty.id);
           bool descriptionEquality = (this.description == newSpecialty.description);
           return (descriptionEquality && idEquality);
         }
       }
    public override int GetHashCode()
       {
         return this.description.GetHashCode();
       }

    public void AddStylist(Stylist newStylist)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO stylists_specialties (stylist_id, specialty_id) VALUES (@StylistId, @SpecialtyId);";

      MySqlParameter specialty_id = new MySqlParameter();
      specialty_id.ParameterName = "@SpecialtyId";
      specialty_id.Value = id;
      cmd.Parameters.Add(specialty_id);

      MySqlParameter stylist_id = new MySqlParameter();
      stylist_id.ParameterName = "@StylistId";
      stylist_id.Value = newStylist.id;
      cmd.Parameters.Add(stylist_id);

      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
    }
    public List<Stylist> GetStylist()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT stylists.* FROM specialties
      JOIN stylists_specialties ON (specialties.id = stylists_specialties.specialty_id)
      JOIN stylists ON (stylists_specialties.stylist_id = stylists.id)
      WHERE specialties.id = @specialtyId;";

      cmd.Parameters.AddWithValue("@specialtyId", id);

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Stylist> stylists = new List<Stylist>{};

      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(0);
        string stylistName = rdr.GetString(1);
        Stylist newStylist = new Stylist(stylistName, stylistId);
        stylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return stylists;
    }

  }
}
