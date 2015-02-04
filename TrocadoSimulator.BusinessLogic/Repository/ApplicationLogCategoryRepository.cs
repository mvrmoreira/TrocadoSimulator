using Dlp.Connectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrocadoSimulator.BusinessLogic.Repository.Entities;

namespace TrocadoSimulator.BusinessLogic.Repository
{
    
    public class ApplicationLogCategoryRepository : AbstractRepository, IApplicationLogCategoryRepository
    {
        public ApplicationLogCategoryRepository(string connectionString) : base(connectionString) { }

        /// <summary>
        /// Query utilizada para selectionar todas as categorias de log.
        /// </summary>
        private const string SelectAllQueryString = @"SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;
                                                      SELECT ApplicationLogCategoryId, Name
                                                      FROM ApplicationLogCategory;";

        /// <summary>
        /// Seleciona todas as categorias cadastradas.
        /// </summary>
        /// <returns>Retorna uma coleção de ApplicationLogCategoryEntity com as entidades encontradas.</returns>
        public IEnumerable<ApplicationLogCategoryEntity> SelectAll() {

            using (DatabaseConnector databaseConnector = new DatabaseConnector(this.ConnectionString)) {

                return databaseConnector.ExecuteReader<ApplicationLogCategoryEntity>(SelectAllQueryString);
            }
        }
    }
}
