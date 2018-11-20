using BusinessLogicWPF.Model;
using BusinessLogicWPF.UnitOfWork.Core.Repositories;
using System.Data.Entity;

namespace BusinessLogicWPF.UnitOfWork.Persistence.Repositories
{
    public class StationMasterRepository : Repository<StationMaster>, IStationMasterRepository
    {
        public RailwayEntities RailwayEntities => Context as RailwayEntities;

        public StationMasterRepository(DbContext context) : base(context)
        {
        }
    }
}
