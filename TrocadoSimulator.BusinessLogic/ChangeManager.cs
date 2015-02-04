using System;
using Dlp.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrocadoSimulator.BusinessLogic.DataContracts;
using TrocadoSimulator.BusinessLogic.Logs;
using TrocadoSimulator.BusinessLogic.Processors;
using TrocadoSimulator.BusinessLogic.Utility;
using TrocadoSimulator.BusinessLogic.Repository;
using TrocadoSimulator.BusinessLogic.Repository.Entities;

namespace TrocadoSimulator.BusinessLogic
{
    public delegate void ProcessorDoneEventHandler(object sender, ProcessorDoneEventArgs e);

    public class ChangeManager
    {
        public ChangeManager()
        {
            IocFactory.Register<IConfigurationUtility, ConfigurationUtility>();
            IocFactory.Register<IApplicationLogCategoryRepository, ApplicationLogCategoryRepository>();
            IocFactory.Register<IApplicationLogRepository, ApplicationLogRepository>();            

            IocFactory.Register<ILogger, FileLogger>(LogRepositoryEnum.File.ToString());
            IocFactory.Register<ILogger, DatabaseLogger>(LogRepositoryEnum.Database.ToString());
            IocFactory.Register<ILogger, WindowsEventLogger>(LogRepositoryEnum.WindowsEvent.ToString());
        }

        /// <summary>
        /// Evento disparado quando um processador finalizar o cálculo.
        /// </summary>
        public event ProcessorDoneEventHandler OnProcessorDone;

        private IConfigurationUtility _configurationUtility;
        public IConfigurationUtility ConfigurationUtility
        {
            get
            {                
                if (this._configurationUtility == null) {
                    this._configurationUtility = IocFactory.Resolve<IConfigurationUtility>();
                }

                return this._configurationUtility;
            }
        }

        public ChangeResponse CalculateChange(ChangeRequest changeRequest)
        {
            ChangeResponse changeResponse = new ChangeResponse();

            // Instancia os loggers
            ILogger fileLogger = LogFactory.Create(LogRepositoryEnum.File);
            ILogger databaseLogger = LogFactory.Create(LogRepositoryEnum.Database);

            try
            {
                //Log information.
                fileLogger.WriteLog(LogSeverityEnum.Information, "Inicio processamento: ", changeRequest);

                // Valida os dados recebidos no request.
                if (changeRequest.IsValid == false)
                {
                    changeResponse.ErrorReport = changeRequest.Errors;
                    changeResponse.Success = false;

                    //Log information.
                    databaseLogger.WriteLog(LogSeverityEnum.Error, "Erro na validação dos dados", changeResponse);

                    return changeResponse;
                }

                // Calcula o troco.
                int originalChangeAmount = changeRequest.PaidAmount - changeRequest.ProductAmount;

                // Instancia coleção de troco
                List<ChangeData> changeDataCollection = new List<ChangeData>();

                //Log information.
                databaseLogger.WriteLog(LogSeverityEnum.Information, "Troco calculado: ", originalChangeAmount);

                // enquanto houver troco
                int changeAmount = originalChangeAmount;
                while (changeAmount > 0)
                {

                    // seleciona o processador
                    AbstractChangeProcessor processor = ProcessorFactory.Create(changeAmount);

                    //Log information.
                    databaseLogger.WriteLog(LogSeverityEnum.Information, string.Format("Processador {0} selecionado", processor.GetName()));

                    // calcula o troco
                    List<ChangeData> processorChangeDataCollection = processor.Calculate(changeAmount);

                    // adiciona o resultado do troco do processador a coleção da resposta
                    changeDataCollection.AddRange(processorChangeDataCollection);

                    // Soma o valor de troco processado
                    int processorChangeAmount = processorChangeDataCollection.Sum(i => i.Quantity * i.AmountInCents);

                    //Log information.
                    databaseLogger.WriteLog(LogSeverityEnum.Information, string.Format("Processador {0} processou {1} de troco em centavos.", processor.GetName(), processorChangeAmount), processorChangeDataCollection);

                    // Dispara um evento informando que o processador terminou o cálculo.
                    if (this.OnProcessorDone != null) { this.OnProcessorDone(this, new ProcessorDoneEventArgs(processor.GetName(), processorChangeAmount)); }

                    // Diminui do troco o valor processado
                    changeAmount -= processorChangeAmount;
                }

                // Atribui a coleção de trocos a resposta
                changeResponse.ChangeDataCollection = changeDataCollection;
                changeResponse.ChangeAmount = originalChangeAmount;

                // Atribui true ao succe
                changeResponse.Success = true;


            }
            catch (Exception ex)
            {
                ILogger eventLogger = LogFactory.Create(LogRepositoryEnum.WindowsEvent);

                ErrorReport errorReport = new ErrorReport();
                errorReport.Field = "Internal Error";
                errorReport.Message = "Ocorreu um erro interno.";

#if DEBUG
                errorReport.Message += " DEBUG:" + ex.ToString();
#endif
                changeResponse.ErrorReport.Add(errorReport);

                eventLogger.WriteLog(LogSeverityEnum.Error, "Ocorreu um erro interno.", errorReport);

                // Retorna sucesso falso
                changeResponse.Success = false;
            }
            finally
            {
                //Log information.
                fileLogger.WriteLog(LogSeverityEnum.Information, "Fim do processamento: ", changeResponse);
            }

            return changeResponse;
        }
    }
}
