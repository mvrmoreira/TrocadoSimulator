using System;
using TrocadoSimulator.BusinessLogic.Logs;
namespace TrocadoSimulator.BusinessLogic.Utility
{
    public interface IConfigurationUtility
    {
        string LogFileName { get; }

        string LogFilePath { get; }

        /// <summary>
        /// Obtém a string de conexão com o banco de dados.
        /// </summary>
        string DatabaseConnection { get; }

        LogRepositoryEnum LogRepository { get; }

        string LogWindowsEventPath { get; }

        string LogWindowsEventName { get; }
    }
}
