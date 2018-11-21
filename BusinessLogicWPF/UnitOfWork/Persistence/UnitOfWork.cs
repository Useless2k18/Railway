using BusinessLogicWPF.Model;
using BusinessLogicWPF.UnitOfWork.Core;
using BusinessLogicWPF.UnitOfWork.Core.Repositories;
using BusinessLogicWPF.UnitOfWork.Persistence.Repositories;

namespace BusinessLogicWPF.UnitOfWork.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RailwayDbContext _context;

        public IStationMasterRepository StationMasters { get; }
        public ITteRepository Ttes { get; }

        public UnitOfWork(RailwayDbContext context)
        {
            _context = context;
            StationMasters = new StationMasterRepository(_context);
            Ttes = new TteRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
