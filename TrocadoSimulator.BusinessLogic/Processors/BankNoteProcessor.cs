using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrocadoSimulator.BusinessLogic.Processors {

    public class BankNoteProcessor : AbstractChangeProcessor {

        public BankNoteProcessor()
            : base()
        {
        }

        /// <summary>
        /// Obtém os valores válidos para este processador.
        /// </summary>
        /// <returns>Retorna um array de int com os valores válidos.</returns>
        public override int[] AvailableValues() {

            return new int[] { 10000, 5000, 2000, 1000, 500, 200 };
        }

        public override string GetName() {
            return "Processador de cédulas";
        }

        protected override bool Validate(int amountInCents)
        {
            return (amountInCents >= this.AvailableValues().Min());
        }

        protected override string GetCurrencyName()
        {
            return "cédula";
        }
    }
}
