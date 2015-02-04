using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TrocadoSimulator.BusinessLogic.Logs;
using Dlp.Framework;
using System.Configuration;
using TrocadoSimulator.BusinessLogic.Utility;
using TrocadoSimulator.BusinessLogic.Repository;

namespace TrocadoSimulator.BusinessLogic {
    public sealed class FileLogger : ILogger {

        public FileLogger(IConfigurationUtility configurationUtility) {

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

            string path = this.ConfigurationUtility.LogFilePath;
            string fileName = this.ConfigurationUtility.LogFileName;
            
            try {
                if (Directory.Exists(path) == false) {
                    Directory.CreateDirectory(path);
                }

                FileStream fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Append);                
                    using (StreamWriter streamWriter = new StreamWriter(fileStream))
                    {
                        string serializedObject = null;
                        if (args != null)
                        {
                            serializedObject = Serializer.JsonSerialize(args);
                        }

                        streamWriter.WriteLine(string.Format("[{0}] [{1}] {2} {3}", DateTime.Now.ToString(), severity.ToString().PadRight(15), message, serializedObject));
                    }
                
            }
            catch (Exception) { }
        }
    }
}
