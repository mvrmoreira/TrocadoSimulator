using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TrocadoSimulator.BusinessLogic.DataContracts {

    public sealed class ChangeResponse : AbstractResponse {

        public int ChangeAmount { get; set; }

        public List<ChangeData> ChangeDataCollection { get; set; }
    }
}
