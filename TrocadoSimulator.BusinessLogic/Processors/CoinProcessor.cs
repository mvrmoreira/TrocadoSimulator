using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrocadoSimulator.BusinessLogic.Processors
{

    public class CoinProcessor : AbstractChangeProcessor
    {

        public CoinProcessor()
            : base()
        {
        }

        /// <summary>
        /// Obtém os valores válidos para este processador.
        /// </summary>
        /// <returns>Retorna um array de int com os valores válidos.</returns>
        public override int[] AvailableValues()
        {

            return new int[] { 100, 50, 25, 10, 5, 1 };
        }

        public override string GetName()
        {
            return "Processador de moedas";
        }

        protected override bool Validate(int amountInCents)
        {
            return (amountInCents >= this.AvailableValues().Min());
        }

        protected override string GetCurrencyName()
        {
            return "moeda";
        }
    }
}
