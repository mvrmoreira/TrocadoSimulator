using System;
using System.Collections.Generic;
using TrocadoSimulator.BusinessLogic.Repository.Entities;

namespace TrocadoSimulator.BusinessLogic.Repository
{
    public interface IApplicationLogCategoryRepository
    {
        IEnumerable<ApplicationLogCategoryEntity> SelectAll();
    }
}
