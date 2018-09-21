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
  }
}
