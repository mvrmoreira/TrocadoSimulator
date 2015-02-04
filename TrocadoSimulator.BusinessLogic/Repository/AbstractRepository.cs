using System;

namespace TrocadoSimulator.BusinessLogic.Repository
{
    public abstract class AbstractRepository
    {
        protected AbstractRepository(string connectionString)
        {
            // Verifica se a connection string foi especificada.
            if (string.IsNullOrWhiteSpace(connectionString) == true) { throw new ArgumentNullException("connectionString"); }

            this.ConnectionString = connectionString;
        }

        /// <summary>
        /// Obtém a string de conexão a ser utilizada para acessar o banco de dados.
        /// </summary>
        protected string ConnectionString { get; private set; }
    }
}
