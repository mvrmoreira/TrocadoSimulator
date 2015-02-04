using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrocadoSimulator.BusinessLogic.Logs;
using TrocadoSimulator.BusinessLogic.Utility;

namespace TrocadoSimulator.Tests.BusinessLogic.Mocks
{
    public class ConfigurationUtilityMock : IConfigurationUtility
    {
        public string LogFileName
        {
            get { return "LogTest.log"; }
        }

        public string LogFilePath
        {
            get { return @"C:\Logs\Tests\"; }
        }

        public string DatabaseConnection
        {
            get { return null; }
        }


        public TrocadoSimulator.BusinessLogic.Logs.LogRepositoryEnum LogRepository
        {
            get { return LogRepositoryEnum.File; }
        }


        public string LogWindowsEventPath
        {
            get { return @"C:\Logs\Tests"; }
        }

        public string LogWindowsEventName
        {
            get { return "WindowsEvent.log"; }
        }
    }
}
