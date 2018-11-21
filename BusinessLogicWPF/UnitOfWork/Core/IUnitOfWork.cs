using BusinessLogicWPF.UnitOfWork.Core.Repositories;
using System;

namespace BusinessLogicWPF.UnitOfWork.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IStationMasterRepository StationMasters { get; }
        ITteRepository Ttes { get; }
        void Complete();
    }
}