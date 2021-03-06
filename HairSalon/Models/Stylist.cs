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
    public static Stylist Find(int id)
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM stylists where id = (@searchId);";

        MySqlParameter searchId = new MySqlParameter();
        searchId.ParameterName = "@searchId";
        searchId.Value = id;
        cmd.Parameters.Add(searchId);

        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        int StylistId = 0;
        string StylistName = "";
        while(rdr.Read())
        {
          StylistId = rdr.GetInt32(0);
          StylistName = rdr.GetString(1);
        }
        Stylist foundStylist = new Stylist(StylistName, StylistId);
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return foundStylist;
      }
    public List<Client> GetClient()
    {
      {
        List<Client> allClients = new List<Client> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @stylist_id;";

        MySqlParameter stylistId = new MySqlParameter();
        stylistId.ParameterName = "@stylist_id";
        stylistId.Value = this.id;
        cmd.Parameters.Add(stylistId);


        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int clientsId = rdr.GetInt32(0);
          string clietsName = rdr.GetString(1);
          int clientsStylistId = rdr.GetInt32(2);
          Client newClient = new Client(clietsName, clientsStylistId, clientsId);
          allClients.Add(newClient);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allClients;
      }
    }
    public static void DeleteAll()
       {
         MySqlConnection conn = DB.Connection();
         conn.Open();

         var cmd = conn.CreateCommand() as MySqlCommand;
         cmd.CommandText = @"DELETE FROM stylists;";

         cmd.ExecuteNonQuery();

         conn.Close();
         if (conn != null)
         {
             conn.Dispose();
         }
       }
    public override bool Equals(System.Object otherStylist)
       {
         if (!(otherStylist is Stylist))
         {
           return false;
         }
         else
         {
           Stylist newStylist = (Stylist) otherStylist;
           bool idEquality = (this.id == newStylist.id);
           bool nameEquality = (this.name == newStylist.name);
           return (nameEquality && idEquality);
         }
       }
    public override int GetHashCode()
       {
         return this.name.GetHashCode();
       }

    public void AddSpecialty(Specialty newSpecialty)
       {
         MySqlConnection conn = DB.Connection();
         conn.Open();
         var cmd = conn.CreateCommand() as MySqlCommand;
         cmd.CommandText = @"INSERT INTO stylists_specialties (stylist_id, specialty_id) VALUES (@stylistId, @specialtyId);";

         MySqlParameter specialty_id = new MySqlParameter();
         specialty_id.ParameterName = "@specialtyId";
         specialty_id.Value = newSpecialty.id;
         cmd.Parameters.Add(specialty_id);

         MySqlParameter stylist_id = new MySqlParameter();
         stylist_id.ParameterName = "@stylistId";
         stylist_id.Value = id;
         cmd.Parameters.Add(stylist_id);

         cmd.ExecuteNonQuery();
         conn.Close();
         if (conn != null)
         {
             conn.Dispose();
         }
   }
       public List<Specialty> GetSpecialty()
       {
         MySqlConnection conn = DB.Connection();
         conn.Open();
         MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
         cmd.CommandText = @"SELECT specialties.* FROM stylists
         JOIN stylists_specialties ON (stylists.id = stylists_specialties.stylist_id)
         JOIN specialties ON (stylists_specialties.specialty_id = specialties.id)
         WHERE stylists.id = @stylistId;";
         cmd.Parameters.AddWithValue("@stylistId", id);

         MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
         List<Specialty> specialties = new List<Specialty>{};

         while(rdr.Read())
         {
           int specialtyId = rdr.GetInt32(0);
           string specialtyDescription = rdr.GetString(1);
           Specialty newSpecialty = new Specialty(specialtyDescription, specialtyId);
           specialties.Add(newSpecialty);
         }
         conn.Close();
         if (conn != null)
         {
           conn.Dispose();
         }
         return specialties;
       }

       public void Delete(int id)
          {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylists WHERE id = @thisId";

            cmd.Parameters.AddWithValue("@thisId", id);

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
          }

      public void Edit(string newName)
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"UPDATE stylists SET name = @newStylistName WHERE id = @searchId;";
          cmd.Parameters.AddWithValue("newStylistName", newName);
          cmd.Parameters.AddWithValue("searchId", this.id);

          cmd.ExecuteNonQuery();
          this.name = newName;

          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
        }
      public static List<Stylist> SearchInStylistTable(string stylistName)
       {
         List<Stylist> allStylists = new List<Stylist>{};
         MySqlConnection conn = DB.Connection();
         conn.Open();
         MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

         cmd.CommandText = @"SELECT * FROM stylists WHERE name LIKE @searchName;";

         cmd.Parameters.AddWithValue("@searchName", "%" + stylistName + "%");

         MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

         while (rdr.Read())
         {
           int stylistId = rdr.GetInt32(0);
           string stylistitle = rdr.GetString(1);

           Stylist newStylist = new Stylist (stylistitle, stylistId);
           allStylists.Add(newStylist);

         }
         conn.Close();
         if (conn !=null)
         {
           conn.Dispose();
         }
         return allStylists;
       }
   
  }
}
