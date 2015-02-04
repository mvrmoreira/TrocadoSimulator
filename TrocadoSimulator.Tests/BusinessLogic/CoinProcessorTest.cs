using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrocadoSimulator.BusinessLogic.Processors;
using TrocadoSimulator.BusinessLogic;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using TrocadoSimulator.Tests.BusinessLogic.Mocks;
using TrocadoSimulator.BusinessLogic.Utility;
using Dlp.Framework;

namespace TrocadoSimulator.Tests.BusinessLogic {
    
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CoinProcessorTest {

        [ClassInitialize]
        public static void ConfigurationInitialize(TestContext testContext)
        {
            // Registra as implementações
            IocFactory.Register<IConfigurationUtility, ConfigurationUtilityMock>();
        }


        [TestMethod]
        public void CalculateCoins_WithValidAmountTest() {            

            CoinProcessor coinProcessor = new CoinProcessor();
            List<ChangeData> coinCollection = coinProcessor.Calculate(99);

            // Afirma que não pode ser nulo
            Assert.IsNotNull(coinCollection);

            // Afirma a quantidade de moedas
            Assert.AreEqual(4, coinCollection.Count);

            // Testa cada tipo de moeda
            Assert.AreEqual(1, coinCollection.SingleOrDefault(o => o.AmountInCents == 50).Quantity);
            Assert.AreEqual(1, coinCollection.SingleOrDefault(o => o.AmountInCents == 25).Quantity);
            Assert.AreEqual(2, coinCollection.SingleOrDefault(o => o.AmountInCents == 10).Quantity);
            Assert.AreEqual(4, coinCollection.SingleOrDefault(o => o.AmountInCents == 1).Quantity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CalculateCoins_NegativeValueTest() {

            CoinProcessor coinProcessor = new CoinProcessor();
            List<ChangeData> coinCollection = coinProcessor.Calculate(-10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CalculateCoins_ZeroValueTest() {

            CoinProcessor coinProcessor = new CoinProcessor();
            List<ChangeData> coinCollection = coinProcessor.Calculate(0);
        }
    }
}
