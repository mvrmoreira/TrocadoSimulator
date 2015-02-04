using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrocadoSimulator.BusinessLogic.Processors;

namespace TrocadoSimulator.BusinessLogic {

    public class ChangeData {

        public ChangeData() {

        }

        public ChangeData(int amountInCents, int quantity) {
            this.AmountInCents = amountInCents;
            this.Quantity = quantity;
        }

        public ChangeData(int amountInCents, string name) {
            this.AmountInCents = amountInCents;
            this.Quantity = 1;
            this.Name = name;
        }
        
        /// <summary>
        /// Obtém ou define o valor do troco em centavos.
        /// </summary>
        public int AmountInCents { get; set; }

        /// <summary>
        /// Obtém ou define a quantidade de unidades monetárias a serem retornadas.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Obtém ou define o nome da unidade monetária.
        /// </summary>
        public string Name { get; set; }
    }
}
