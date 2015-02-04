using Dlp.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrocadoSimulator.BusinessLogic.Logs;
using TrocadoSimulator.BusinessLogic.Utility;

namespace TrocadoSimulator.BusinessLogic
{
    public static class LogFactory
    {
        public static ILogger Create(LogRepositoryEnum logRepository)
        {
            IConfigurationUtility configurationUtility = IocFactory.Resolve<IConfigurationUtility>();

            return IocFactory.ResolveSpecific<ILogger>(logRepository.ToString(), configurationUtility);
        }
    }
}
