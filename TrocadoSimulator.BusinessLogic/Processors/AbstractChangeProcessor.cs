using Dlp.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrocadoSimulator.BusinessLogic.Logs;
using TrocadoSimulator.BusinessLogic.Utility;

namespace TrocadoSimulator.BusinessLogic.Processors {

    public abstract class AbstractChangeProcessor {

        public AbstractChangeProcessor() { }

        public abstract int[] AvailableValues();

        public abstract string GetName();

        protected abstract bool Validate(int amountInCents);

        protected abstract string GetCurrencyName();

        public List<ChangeData> Calculate(int amountInCents) {

            // Executa a validação dos dados recebidos.
            if (this.Validate(amountInCents) == false) { throw new ArgumentOutOfRangeException("amountInCents", "Value must be equals  or greater than zero."); }

            List<ChangeData> changeDataCollection = new List<ChangeData>();

            int[] availableValues = this.AvailableValues();

            // Lista ordenada do menor para o maior
            int[] orderedCollection = availableValues.OrderByDescending(p => p).ToArray();

            IConfigurationUtility configurationUtility = IocFactory.Resolve<IConfigurationUtility>();
            ILogger logManager = IocFactory.Resolve<ILogger>(configurationUtility);

            logManager.WriteLog(LogSeverityEnum.Information, string.Format("{0}: orderedCollection", this.GetName()), orderedCollection);

            // Armazena o menor valor disponível.
            int minValue = availableValues.Min();

            // Iteração sobre todas as moedas
            foreach (int changeItem in orderedCollection)
            {
                //Enquanto o valor do troco restante for igual ou menor ao valor da moeda, adiciona a lista
                while (changeItem <= amountInCents)
                {
                    //Se o troco restante for zero, retorna o valor
                    if (amountInCents < minValue)
                    {
                        return changeDataCollection;
                    }

                    //Recupera o item a ser adicionado na lista, caso já esteja apenas incrementa.
                    ChangeData changeData = changeDataCollection.SingleOrDefault(o => o.AmountInCents == changeItem);

                    if (changeData == null)
                    {

                        changeDataCollection.Add(new ChangeData(changeItem, this.GetCurrencyName()));
                    }
                    else
                    {
                        changeData.Quantity++;
                    }

                    amountInCents = amountInCents - changeItem;
                }
            }

            return changeDataCollection;
        }
    }
}
