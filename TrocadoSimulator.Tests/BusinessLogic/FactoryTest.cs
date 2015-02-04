using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrocadoSimulator.BusinessLogic.Processors;
using System.Diagnostics.CodeAnalysis;
using TrocadoSimulator.BusinessLogic.Utility;
using TrocadoSimulator.BusinessLogic;
using Dlp.Framework;
using TrocadoSimulator.Tests.BusinessLogic.Mocks;

namespace TrocadoSimulator.Tests.BusinessLogic {
    /// <summary>
    /// Summary description for FactoryTest
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class FactoryTest {
        
        public FactoryTest() {
            //
            // TODO: Add constructor logic here
            //
        }

        static IConfigurationUtility configurationUtility;
        static ILogger logManager = new FileLogger(configurationUtility);

        [ClassInitialize]
        public static void ConfigurationInitialize(TestContext testContext)
        {
            // Registra as implementações
            IocFactory.Register<IConfigurationUtility, ConfigurationUtilityMock>();

            configurationUtility = new Mocks.ConfigurationUtilityMock();
        }

        
        [TestMethod]
        public void Processor_BankNoteFactoryTest() {
            AbstractChangeProcessor abstractProcessor = ProcessorFactory.Create(200);
            Assert.IsNotNull(abstractProcessor);
            Assert.IsTrue(abstractProcessor is BankNoteProcessor);
        }
        
        [TestMethod]
        public void Processor_CoinFactoryTest() {
            AbstractChangeProcessor abstractProcessor = ProcessorFactory.Create(74);
            Assert.IsNotNull(abstractProcessor);
            Assert.IsTrue(abstractProcessor is CoinProcessor);
        }

        [TestMethod]
        public void Processor_NegativeChangeAmount() {

            AbstractChangeProcessor abstractProcessor = ProcessorFactory.Create(-3);
            Assert.IsNull(abstractProcessor);
        }
    }
}
