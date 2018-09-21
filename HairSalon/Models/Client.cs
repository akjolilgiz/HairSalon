using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;
using System;

namespace HairSalon.Models
{
  public class Client
  {
    public int id {get; set; }
    public string clientName {get; set; }
    public int stylist_id {get; set; }

    public Client(string newName, int stylistId, int Id = 0)
      {
        id = Id;
        clientName = newName;
        stylist_id = stylistId;
      }

    public static List<Client> GetAll()
      {
        List<Client> allClients = new List<Client> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM clients;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int clientsId = rdr.GetInt32(0);
          string clientsName = rdr.GetString(1);
          int clientsStylistID = rdr.GetInt32(2);
          Client newClient = new Client(clientsName, clientsStylistID, clientsId);
          allClients.Add(newClient);
        }
        conn.Close();
        if (conn !=null)
        {
          conn.Dispose();
        }
        return allClients;
      }
    public void Save()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"INSERT INTO clients (clientName, stylist_id) VALUES (@ClientsName, @StylistId);";

        MySqlParameter newName = new MySqlParameter();
        newName.ParameterName = "@ClientsName";
        newName.Value = this.clientName;
        cmd.Parameters.Add(newName);

        MySqlParameter newStylistID = new MySqlParameter();
        newStylistID.ParameterName = @"StylistId";
        newStylistID.Value = this.stylist_id;
        cmd.Parameters.Add(newStylistID);


        cmd.ExecuteNonQuery();
        id = (int) cmd.LastInsertedId;

        conn.Close();
        if (conn !=null)
        {
          conn.Dispose();
        }
      }
      public static Client Find(int id)
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();

          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM clients WHERE id = @thisId;";

          MySqlParameter thisId = new MySqlParameter();
          thisId.ParameterName = "@thisId";
          thisId.Value = id;
          cmd.Parameters.Add(thisId);

          var rdr = cmd.ExecuteReader() as MySqlDataReader;

          int clientsId = 0;
          string clientsName = "";
          int clientsStylistID = 0;

          while (rdr.Read())
          {
              clientsId = rdr.GetInt32(0);
              clientsName = rdr.GetString(1);
              clientsStylistID = rdr.GetInt32(2);
          }

          Client foundClient= new Client(clientsName, clientsStylistID, clientsId);  // This line is new!

           conn.Close();
           if (conn != null)
           {
               conn.Dispose();
           }
           return foundClient;
         }
       public void Edit(string newName, int newStylistID)
         {
           MySqlConnection conn = DB.Connection();
           conn.Open();
           var cmd = conn.CreateCommand() as MySqlCommand;
           cmd.CommandText = @"UPDATE clients SET clientName = @newClientName, stylist_id = @newStylistId WHERE id = @searchId;";

           MySqlParameter searchId = new MySqlParameter();
           searchId.ParameterName = "@searchId";
           searchId.Value = id;
           cmd.Parameters.Add(searchId);

           MySqlParameter clientsName = new MySqlParameter();
           clientsName.ParameterName = "@newClientName";
           clientsName.Value = newName;
           cmd.Parameters.Add(clientsName);

           MySqlParameter clientsStylistId = new MySqlParameter();
           clientsStylistId.ParameterName = "@newStylistId";
           clientsStylistId.Value = newStylistID;
           cmd.Parameters.Add(clientsStylistId);

           cmd.ExecuteNonQuery();
           clientName = newName;
           stylist_id = newStylistID;

           conn.Close();
           if (conn != null)
           {
               conn.Dispose();
           }
         }
      public void Delete(int id)
         {
           MySqlConnection conn = DB.Connection();
           conn.Open();
           var cmd = conn.CreateCommand() as MySqlCommand;
           cmd.CommandText = @"DELETE FROM items WHERE id = @thisId";

           MySqlParameter searchId = new MySqlParameter();
           searchId.ParameterName = "@thisId";
           searchId.Value = id;
         cmd.Parameters.Add(searchId);

           cmd.ExecuteNonQuery();

           conn.Close();
           if (conn != null)
           {
               conn.Dispose();
           }
         }


      public static void DeleteAll()
         {
           MySqlConnection conn = DB.Connection();
           conn.Open();

           var cmd = conn.CreateCommand() as MySqlCommand;
           cmd.CommandText = @"DELETE FROM clients;";

           cmd.ExecuteNonQuery();

           conn.Close();
           if (conn != null)
           {
               conn.Dispose();
           }
         }
      public override bool Equals(System.Object otherClient)
         {
           if (!(otherClient is Client))
           {
             return false;
           }
           else
           {

             Client newClient = (Client) otherClient;
             bool idEquality = (this.id == newClient.id);
             bool nameEquality = (this.clientName == newClient.clientName);
             return (nameEquality && idEquality);
           }
         }
      public override int GetHashCode()
         {
           return this.clientName.GetHashCode();
         }

  }
}
