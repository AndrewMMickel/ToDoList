using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ToDoList.Models;
using ToDoList;

namespace ToDoListTests
{
    [TestClass]
    public class ItemTests : IDisposable
    {
        public void Dispose()
        {
            Item.ClearAll();
        }

        public ItemTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=to_do_list_test;";
        }

        [TestMethod]
        public void ItemConstructor_CreatesInstanceOfItem_Item()
        {
            Item newItem = new Item("test");
            Assert.AreEqual(typeof(Item), newItem.GetType());
        }

        [TestMethod]
        public void GetDescription_ReturnsDescription_String()
        {
            // Arrange
            List<Item> newList = new List<Item>();

            // Act
            List<Item> result = Item.GetAll();

            // Assert
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void SetDescription_SetDescription_String()
        {
            // Arrange
            string description = "Walk the dog.";
            Item newItem = new Item(description);

            // Act
            string updatedDescription = "Do the dishes";
            newItem.Description = updatedDescription;
            string result = newItem.Description;

            // Assert
            Assert.AreEqual(updatedDescription, result);
        }

        [TestMethod]
        public void GetAll_ReturnsEmptyList_ItemList()
        {
            // Arrange
            List<Item> newList = new List<Item>();

            // Act
            List<Item> result = Item.GetAll();

            // Assert
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void GetAll_ReturnsItems_ItemList()
        {
            //Arrange
            string description01 = "Walk the dog";
            string description02 = "Wash the dishes";
            Item newItem1 = new Item(description01);
            newItem1.Save(); // New code
            Item newItem2 = new Item(description02);
            newItem2.Save(); // New code
            List<Item> newList = new List<Item> { newItem1, newItem2 };

            //Act
            List<Item> result = Item.GetAll();

            //Assert
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void GetId_ItemsInstantiateWithAnIdAndGetterReturns_Int()
        {
            // Arrange
            List<Item> newList = new List<Item>();

            // Act
            List<Item> result = Item.GetAll();

            // Assert
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void Find_ReturnsCorrectItem_Item()
        {
            // Arrange
            List<Item> newList = new List<Item>();

            // Act
            List<Item> result = Item.GetAll();

            // Assert
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void Save_SavesToDatabase_ItemList()
        {
            //Arrange
            Item testItem = new Item("Mow the lawn");

            //Act
            testItem.Save();
            List<Item> result = Item.GetAll();
            List<Item> testList = new List<Item> { testItem };

            //Assert
            CollectionAssert.AreEqual(testList, result);
        }


    }
}