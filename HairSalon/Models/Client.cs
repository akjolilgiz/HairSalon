using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;
using System;

namespace HairSalon.Models
{
  public class Client
  {
    public int id {get; set; }
    public string name {get; set; }

    public Client(string newName, int Id = 0)
    {
      id = Id;
      name = newName;
    }
  }
}
