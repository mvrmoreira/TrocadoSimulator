using Dlp.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrocadoSimulator.BusinessLogic.Logs;
using TrocadoSimulator.BusinessLogic.Repository;
using TrocadoSimulator.BusinessLogic.Utility;

namespace TrocadoSimulator.BusinessLogic
{
    public class DatabaseLogger : ILogger
    {
        public DatabaseLogger(IConfigurationUtility configurationUtility) {

            this.ConfigurationUtility = configurationUtility;
        }

        /// <summary>
        /// Obtém uma instancia para o utilitário de acesso ao arquivo de configuração.
        /// </summary>
        private IConfigurationUtility ConfigurationUtility { get; set; }

        private IApplicationLogRepository _applicationLogRepository;
        private IApplicationLogRepository ApplicationLogRepository {
            get {
                if (this._applicationLogRepository == null) { this._applicationLogRepository = IocFactory.Resolve<IApplicationLogRepository>(this.ConfigurationUtility.DatabaseConnection); }
                return this._applicationLogRepository;
            }
        }

        /// <summary>
        /// Escreve log em um arquivo.
        /// </summary>
        /// <param name="message">Mensagem para logar.</param>
        public void WriteLog(LogSeverityEnum severity, string message, object args = null) {

            string serializedObject = null;
            if (args != null) {
                serializedObject = Serializer.JsonSerialize(args);
            }

            message = string.Format("{0} {1}", message, serializedObject);

            this.ApplicationLogRepository.Insert((short) severity, message);
        }
    }
}
