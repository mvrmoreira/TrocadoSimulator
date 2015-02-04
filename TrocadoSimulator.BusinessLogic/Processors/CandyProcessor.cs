using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrocadoSimulator.BusinessLogic.Logs;

namespace TrocadoSimulator.BusinessLogic.Processors
{
    public class CandyProcessor : AbstractChangeProcessor
    {
        public CandyProcessor()
            : base()
        {
        }

        public override int[] AvailableValues()
        {
            return new int[] { 125, 120, 115, 110, 105, 100, 95, 90, 85, 80, 75 };
        }

        public override string GetName()
        {
            return "Processador de balinhas";
        }

        protected override bool Validate(int amountInCents)
        {
            return (amountInCents >= this.AvailableValues().Min());
        }

        protected override string GetCurrencyName()
        {
            return "balinha";
        }
    }
}
