using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace HairSalon.Tests
{
  [TestClass]
   public class ClientTests : IDisposable
   {
     public void Dispose()
     {
       Client.DeleteAll();
     }
     public ClientTests()
     {
       DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=akjol_jaenbai_test;";
     }
     [TestMethod]
     public void GetAll_DbStartsEmpty_0()
     {
       //Arrange
       //Act
       int result = Client.GetAll().Count;

       //Assert
       Assert.AreEqual(0, result);
     }
     [TestMethod]
     public void Equals_ReturnsTrueIfNamesAreTheSame_Client()
     {
       // Arrange, Act
       Client firstClient = new Client("Mow the lawn", 1);
       Client secondClient = new Client("Mow the lawn", 1);

       // Assert
       Assert.AreEqual(firstClient, secondClient);
     }
     [TestMethod]
      public void Save_SavesToDatabase_ClientList()
      {
        //Arrange
        Client testClient = new Client("Mow the lawn", 1);

        //Act
        testClient.Save();
        List<Client> result = Client.GetAll();
        List<Client> testList = new List<Client>{testClient};

        //Assert
      }

    [TestMethod]
      public void Find_FindsClientInDatabase_Client()
      {
          //Arrange
          Client testClient = new Client("Mow the lawn", 1);
          testClient.Save();

          //Act
          Client foundClient = Client.Find(testClient.id);

          //Assert
          Assert.AreEqual(testClient, foundClient);
      }
    [TestMethod]
     public void Edit_UpdatesClientInDatabase_String()
     {
         //Arrange
         string firstClient = "walk the dog";
         Client testClient = new Client (firstClient, 1);
         testClient.Save();
         string secondClient = "Mow the lawn";

         //Act
         testClient.Edit(secondClient, 1);

         string result = Client.Find(testClient.id).clientName;

         //Assert
         Assert.AreEqual(secondClient, result);
     }
  }
}
