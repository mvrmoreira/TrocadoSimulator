using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrocadoSimulator.BusinessLogic.Logs;

namespace TrocadoSimulator.BusinessLogic.Utility
{
    public sealed class ConfigurationUtility : IConfigurationUtility
    {
        /// <summary>
        /// Obtém o caminho do arquivo de log.
        /// </summary>
        public string LogFilePath { get { return ConfigurationManager.AppSettings["LogFilePath"]; } }

        /// <summary>
        /// Obtém o nome do arquivo de log.
        /// </summary>
        public string LogFileName { get { return ConfigurationManager.AppSettings["LogFileName"]; } }

        /// <summary>
        /// Obtém a string de conexão com o banco de dados.
        /// </summary>
        public string DatabaseConnection { get { return ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString; } }

        public LogRepositoryEnum LogRepository { get { return (LogRepositoryEnum)Enum.Parse(typeof(LogRepositoryEnum), ConfigurationManager.AppSettings["LogRepository"]); } }


        /// <summary>
        /// Obtém o caminho do arquivo de log (evento do Windows).
        /// </summary>
        public string LogWindowsEventPath { get { return ConfigurationManager.AppSettings["LogWindowsEventPath"]; } }

        /// <summary>
        /// Obtém o nome do arquivo de log (evento do Windows).
        /// </summary>
        public string LogWindowsEventName { get { return ConfigurationManager.AppSettings["LogWindowsEventName"]; } }
    }
}
