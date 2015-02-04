using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrocadoSimulator.BusinessLogic.Repository.Entities
{
    public sealed class ApplicationLogCategoryEntity
    {
        public ApplicationLogCategoryEntity() { }

        public short ApplicationLogCategoryId { get; set; }

        public string Name { get; set; }
    }
}
