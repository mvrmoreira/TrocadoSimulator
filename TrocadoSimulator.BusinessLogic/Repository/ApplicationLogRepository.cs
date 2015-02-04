using Dlp.Connectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrocadoSimulator.BusinessLogic.Repository
{
    public class ApplicationLogRepository : AbstractRepository, IApplicationLogRepository
    {
        public ApplicationLogRepository(string connectionString) : base(connectionString)
        {

        }

        const string InsertQueryString = @"INSERT INTO ApplicationLog ([ApplicationLogCategoryId], [Message])
                                                               VALUES (@ApplicationLogCategoryId, @Message)";

        public bool Insert(short severidade, string message)
        {
            using (DatabaseConnector databaseConnector = new DatabaseConnector(this.ConnectionString))
            {
                return (databaseConnector.ExecuteNonQuery(InsertQueryString, 
                    new { ApplicationLogCategoryId = severidade, Message = message })) > 0;

            }
        }
    }
}
