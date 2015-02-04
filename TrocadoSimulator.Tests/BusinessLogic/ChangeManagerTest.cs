using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrocadoSimulator.BusinessLogic;
using TrocadoSimulator.BusinessLogic.DataContracts;
using System.Diagnostics.CodeAnalysis;
using TrocadoSimulator.BusinessLogic.Utility;
using Dlp.Framework;
using TrocadoSimulator.Tests.BusinessLogic.Mocks;

namespace TrocadoSimulator.Tests.BusinessLogic {
    /// <summary>
    /// Summary description for ChangeManagerTest
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ChangeManagerTest {
        public ChangeManagerTest() {
            //
            // TODO: Add constructor logic here
            //
        }

        static IConfigurationUtility configurationUtility;

        [ClassInitialize]
        public static void ConfigurationInitialize(TestContext testContext)
        {
            // Registra as implementações
            IocFactory.Register<IConfigurationUtility, ConfigurationUtilityMock>();
            IocFactory.Register<ILogger, FileLogger>();

            configurationUtility = new Mocks.ConfigurationUtilityMock();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CalculateChange_WithValidValue()
        {
            ChangeManager changeManager = new ChangeManager();

            ChangeRequest changeRequest = new ChangeRequest();

            changeRequest.PaidAmount = 73891;
            changeRequest.ProductAmount = 100;
            ChangeResponse changeResponse = changeManager.CalculateChange(changeRequest);

            Assert.IsNotNull(changeResponse);
            Assert.IsNotNull(changeResponse.ChangeDataCollection);
            Assert.AreEqual(7, changeResponse.ChangeDataCollection.SingleOrDefault(o => o.AmountInCents == 10000).Quantity);
            Assert.AreEqual(1, changeResponse.ChangeDataCollection.SingleOrDefault(o => o.AmountInCents == 2000).Quantity);
            Assert.AreEqual(1, changeResponse.ChangeDataCollection.SingleOrDefault(o => o.AmountInCents == 1000).Quantity);
            Assert.AreEqual(1, changeResponse.ChangeDataCollection.SingleOrDefault(o => o.AmountInCents == 500).Quantity);
            Assert.AreEqual(1, changeResponse.ChangeDataCollection.SingleOrDefault(o => o.AmountInCents == 200).Quantity);

            Assert.AreEqual(1, changeResponse.ChangeDataCollection.SingleOrDefault(o => o.AmountInCents == 90).Quantity);

            Assert.AreEqual(1, changeResponse.ChangeDataCollection.SingleOrDefault(o => o.AmountInCents == 1).Quantity);

        }

        [TestMethod]
        public void CalculateChange_NegativeProductAmount()
        {
            ChangeManager changeManager = new ChangeManager();

            IocFactory.Register<IConfigurationUtility, ConfigurationUtilityMock>();

            ChangeRequest changeRequest = new ChangeRequest();

            changeRequest.PaidAmount = 100;
            changeRequest.ProductAmount = -100;
            ChangeResponse changeResponse = changeManager.CalculateChange(changeRequest);

            Assert.IsNotNull(changeResponse);
            Assert.IsNotNull(changeResponse.ErrorReport);
            Assert.AreEqual(changeResponse.ErrorReport.Count(), 1);
            Assert.AreEqual(changeResponse.ErrorReport[0].Field, "ChangeRequest.ProductAmount");
            Assert.AreEqual(changeResponse.ChangeAmount, 0);
        }
    }
}
