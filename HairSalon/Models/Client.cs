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
    public int client_id {get; set; }

    public Client(string newName, int clientId, int Id = 0)
      {
        id = Id;
        clientName = newName;
        client_id = clientId;
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
  }
}
