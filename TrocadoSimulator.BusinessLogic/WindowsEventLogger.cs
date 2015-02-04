using Dlp.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TrocadoSimulator.BusinessLogic.Logs;
using TrocadoSimulator.BusinessLogic.Repository;
using TrocadoSimulator.BusinessLogic.Utility;

namespace TrocadoSimulator.BusinessLogic
{
    public sealed class WindowsEventLogger : ILogger
    {
        public WindowsEventLogger(IConfigurationUtility configurationUtility)
        {

            this.ConfigurationUtility = configurationUtility;
        }

        /// <summary>
        /// Obtém uma instancia para o utilitário de acesso ao arquivo de configuração.
        /// </summary>
        private IConfigurationUtility ConfigurationUtility { get; set; }

        /// <summary>
        /// Escreve log em um arquivo.
        /// </summary>
        /// <param name="message">Mensagem para logar.</param>
        public void WriteLog(LogSeverityEnum severity, string message, object args = null) {
            string serializedObject = null;
            if (args != null) {
                serializedObject = Serializer.JsonSerialize(args);
            }

            string sSource = Assembly.GetCallingAssembly().FullName;
            string sLog = string.Format(CultureInfo.InvariantCulture, "{0} {1}", message, serializedObject);
            string sEvent = severity.ToString();

            if (!EventLog.SourceExists(sSource))
                EventLog.CreateEventSource(sSource, "Application");

            EventLog.WriteEntry(sSource, sLog);
        }
    }
}
