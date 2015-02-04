using Dlp.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrocadoSimulator.BusinessLogic.Processors;
using TrocadoSimulator.BusinessLogic.Utility;

namespace TrocadoSimulator.BusinessLogic.Processors {

    public static class ProcessorFactory {

        public static AbstractChangeProcessor Create(int amountInCents) {

            // Sai do método caso o valor informado não seja válido.
            if (amountInCents <= 0) { return null; }

            List<AbstractChangeProcessor> processorCollection = new List<AbstractChangeProcessor>();

            processorCollection.Add(new CoinProcessor());
            processorCollection.Add(new BankNoteProcessor());
            processorCollection.Add(new CandyProcessor());

            // Adiciona novos processadores acima desta linha.

            AbstractChangeProcessor selectedProcessor = null;
            
            IEnumerable<AbstractChangeProcessor> orderedProcessorCollection = processorCollection.OrderByDescending(p => p.AvailableValues().Min());
            foreach (AbstractChangeProcessor processor in orderedProcessorCollection) {

                if (processor.AvailableValues().Min() <= amountInCents){
                    selectedProcessor = processor;
                    break;
                }
            }

            return selectedProcessor;
        }
    }
}
