using BusinessLogicWPF.Model;
using BusinessLogicWPF.UnitOfWork.Core.Repositories;
using System.Data.Entity;

namespace BusinessLogicWPF.UnitOfWork.Persistence.Repositories
{
    public class TteRepository : Repository<Tte>, ITteRepository
    {
        public RailwayDbContext RailwayDbContext => Context as RailwayDbContext;

        public TteRepository(DbContext context) : base(context)
        {
        }
    }
}
