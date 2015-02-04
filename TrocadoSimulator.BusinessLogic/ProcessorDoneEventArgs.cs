using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrocadoSimulator.BusinessLogic
{
    public sealed class ProcessorDoneEventArgs : EventArgs
    {
        public ProcessorDoneEventArgs() : base() { }

        public ProcessorDoneEventArgs(string name, int changeAmountInCents)
            : base()
        {
            this.Name = name;
            this.ChangeAmountInCents = changeAmountInCents;
        }

        public string Name { get; set; }

        public int ChangeAmountInCents { get; set; }
    }
}
