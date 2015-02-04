using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrocadoSimulator.BusinessLogic.DataContracts {

    public abstract class AbstractResponse {

        protected AbstractResponse()
        {
            this.ErrorReport = new List<ErrorReport>();
        }

        public bool Success { get; set; }

        public List<ErrorReport> ErrorReport { get; set; }
    }
}
