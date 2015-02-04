using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrocadoSimulator.BusinessLogic.Logs
{
    public enum LogRepositoryEnum
    {
        Undefined = 0,
        File = 1,
        Database = 2,
        WindowsEvent = 3
    }
}
