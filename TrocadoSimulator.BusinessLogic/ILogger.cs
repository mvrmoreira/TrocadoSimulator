using System;
using TrocadoSimulator.BusinessLogic.Logs;
namespace TrocadoSimulator.BusinessLogic
{
    public interface ILogger
    {
        /// <summary>
        /// Escreve log em um arquivo.
        /// </summary>
        /// <param name="message">Mensagem para logar.</param>
        void WriteLog(LogSeverityEnum severity, string message, object args = null);
    }
}
