using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrocadoSimulator.BusinessLogic.DataContracts {
    /// <summary>
    /// Contrato de requisição de troco.
    /// </summary>
    public sealed class ChangeRequest : AbstractRequest {
        
        /// <summary>
        /// Valor pago.
        /// </summary>
        public int PaidAmount { get; set; }

        /// <summary>
        /// Valor do produto.
        /// </summary>
        public int ProductAmount { get; set; }

        protected override void Validate() {

            if (this.PaidAmount < 0) {
                this.AddError("PaidAmount", "O valor pago não pode ser menor que zero.");
            }

            if (this.ProductAmount < 0) {
                this.AddError("ProductAmount", "O valor do produto não pode ser menor que zero.");
            }

            if (this.PaidAmount < this.ProductAmount) {
                this.AddError("PaidAmount", "O valor pago não pode ser menor que o valor do produto.");
            }
        }
    }
}
