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
  }
}
