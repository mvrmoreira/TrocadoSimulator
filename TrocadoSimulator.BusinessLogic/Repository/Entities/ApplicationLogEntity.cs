using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrocadoSimulator.BusinessLogic.Repository.Entities
{
    public sealed class ApplicationLogEntity
    {
        public long ApplicationLogId { get; set; }

        public DateTime CreateDate { get; set; }

        public short ApplicationLogCategoryId { get; set; }

        public string Message { get; set; }
    }
}
