﻿using System.Dynamic;
using Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Repository.Tests
{
    
    
    /// <summary>
    ///This is a test class for InMemoryRepositoryTest and is intended
    ///to contain all InMemoryRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class InMemoryRepositoryTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        [TestMethod()]
        public void UpdateTest()
        {
            var repository = new InMemoryRepository<TestClass>(x => x.Key);
            repository.Store(new TestClass());
            repository.Update(new { Value2 = DateTime.MaxValue }, 1);

            var val = repository.Find(1).Object;
            Assert.AreEqual(val.Value2, DateTime.MaxValue);

            var obj = new { Value2 = DateTime.MaxValue };
            repository.Update(obj, x => x.Property, 1);
            Assert.AreEqual(val.Property.Value2, DateTime.MaxValue);
            Assert.AreEqual(val.Property.Value1.Value, 1);

        }
    }
}
