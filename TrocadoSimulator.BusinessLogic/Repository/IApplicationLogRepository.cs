using System;
namespace TrocadoSimulator.BusinessLogic.Repository
{
    interface IApplicationLogRepository
    {
        bool Insert(short severity, string message);
    }
}
