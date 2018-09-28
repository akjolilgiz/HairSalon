using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace HairSalon.Tests
{
  [TestClass]
   public class StylistTests : IDisposable
   {
     public void Dispose()
     {
       Stylist.DeleteAll();
     }
     public StylistTests()
     {
       DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=akjol_jaenbai_test;";
     }
     [TestMethod]
     public void GetAll_DbStartsEmpty_0()
     {
       //Arrange
       //Act
       int result = Stylist.GetAll().Count;

       //Assert
       Assert.AreEqual(0, result);
     }
     [TestMethod]
     public void Equals_ReturnsTrueIfNamesAreTheSame_Stylist()
     {
       // Arrange, Act
       Stylist firstStylist = new Stylist("Mow the lawn");
       Stylist secondStylist = new Stylist("Mow the lawn");

       // Assert
       Assert.AreEqual(firstStylist, secondStylist);
     }

     [TestMethod]
      public void Save_SavesToDatabase_StylistList()
      {
        //Arrange
        Stylist testStylist = new Stylist("Mow the lawn", 1);

        //Act
        testStylist.Save();
        List<Stylist> result = Stylist.GetAll();
        List<Stylist> testList = new List<Stylist>{testStylist};

        //Assert
      }


    [TestMethod]
      public void Find_FindsStylistInDatabase_Stylist()
      {
          //Arrange
          Stylist testStylist = new Stylist("Mow the lawn", 1);
          testStylist.Save();

          //Act
          Stylist foundStylist = Stylist.Find(testStylist.id);

          //Assert
          Assert.AreEqual(testStylist, foundStylist);
      }
    [TestMethod]
     public void Edit_UpdatesStylistInDatabase_String()
     {
         //Arrange
         string firstStylist = "walk the dog";
         Stylist testStylist = new Stylist (firstStylist, 1);
         testStylist.Save();
         string secondStylist = "Mow the lawn";

         //Act
         testStylist.Edit(secondStylist);

         string result = Stylist.Find(testStylist.id).name;

         //Assert
         Assert.AreEqual(secondStylist, result);
     }

  }
}
