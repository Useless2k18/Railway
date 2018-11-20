using BusinessLogicWPF.Model;
using BusinessLogicWPF.UnitOfWork.Core;
using BusinessLogicWPF.UnitOfWork.Core.Repositories;
using BusinessLogicWPF.UnitOfWork.Persistence.Repositories;

namespace BusinessLogicWPF.UnitOfWork.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RailwayEntities _context;

        public UnitOfWork(RailwayEntities context)
        {
            _context = context;
            StationMasters = new StationMasterRepository(_context);
        }

        public IStationMasterRepository StationMasters { get; set; }

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
