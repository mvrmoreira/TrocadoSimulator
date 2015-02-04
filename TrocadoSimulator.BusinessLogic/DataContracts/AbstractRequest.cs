using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrocadoSimulator.BusinessLogic.DataContracts;

namespace TrocadoSimulator.BusinessLogic.DataContracts {

    public abstract class AbstractRequest {

        protected AbstractRequest()
        {
            this.ErrorReportCollection = new List<ErrorReport>();
        }

        /// <summary>
        /// Verifica se o request é válido.
        /// </summary>
        internal bool IsValid {
            get {
                this.Validate();
                return (this.ErrorReportCollection.Any() == false);
            }
        }

        /// <summary>
        /// Obtém os erros encontrados durante a validação.
        /// </summary>
        private List<ErrorReport> ErrorReportCollection { get; set; }

        /// <summary>
        /// Obtém os erros encontrados durante a validação.
        /// </summary>
        internal List<ErrorReport> Errors {
            get { return this.ErrorReportCollection.ToList(); }
        }

        /// <summary>
        /// Executa a validação dos dados recebidos no request.
        /// </summary>
        protected abstract void Validate();

        /// <summary>
        /// Adiciona um erro na coleção de erros a serem retornados.
        /// </summary>
        /// <param name="field">Nome da propriedade que gerou o erro.</param>
        /// <param name="message">Descrição do erro ocorrido.</param>
        protected void AddError(string field, string message) {

            if (string.IsNullOrWhiteSpace(field) == true) { return; }

            if (string.IsNullOrWhiteSpace(message) == true) { return; }

            string requestName = this.GetType().Name;

            string fieldFullName = field;

            // Verifica se já foi informado o nome da classe.
            if (field.StartsWith(requestName, StringComparison.InvariantCulture) == false) {
                fieldFullName = requestName + "." + fieldFullName;
            }

            ErrorReport errorReport = new ErrorReport();

            errorReport.Field = fieldFullName;
            errorReport.Message = message;

            this.ErrorReportCollection.Add(errorReport);
        }
    }
}
