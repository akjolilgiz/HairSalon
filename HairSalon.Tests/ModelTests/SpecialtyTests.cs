using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace HairSalon.Tests
{
  [TestClass]
   public class SpecialtyTests : IDisposable
   {
     public void Dispose()
     {
       Specialty.DeleteAll();
     }
     public SpecialtyTests()
     {
       DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=akjol_jaenbai_test;";
     }
     [TestMethod]
     public void GetAll_DbStartsEmpty_0()
     {
       //Arrange
       //Act
       int result = Specialty.GetAll().Count;

       //Assert
       Assert.AreEqual(0, result);
     }
     [TestMethod]
     public void Equals_ReturnsTrueIfNamesAreTheSame_Specialty()
     {
       // Arrange, Act
       Specialty firstSpecialty = new Specialty("Mow the lawn");
       Specialty secondSpecialty = new Specialty("Mow the lawn");

       // Assert
       Assert.AreEqual(firstSpecialty, secondSpecialty);
     }

     [TestMethod]
      public void Save_SavesToDatabase_Specialty()
      {
        //Arrange
        Specialty testSpecialty = new Specialty("Mow the lawn", 1);

        //Act
        testSpecialty.Save();
        List<Specialty> result = Specialty.GetAll();
        List<Specialty> testList = new List<Specialty>{testSpecialty};

        //Assert
      }

    //
    [TestMethod]
      public void Find_FindsSpecialtyInDatabase_Specialty()
      {
          //Arrange
          Specialty testSpecialty = new Specialty("Mow the lawn", 1);
          testSpecialty.Save();

          //Act
          Specialty foundSpecialty = Specialty.Find(testSpecialty.id);

          //Assert
          Assert.AreEqual(testSpecialty, foundSpecialty);
      }
  

  }
}
