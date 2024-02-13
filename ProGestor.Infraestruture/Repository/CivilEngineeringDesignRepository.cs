using ProGestor.Common.Entities;
using ProGestor.Common.Interfaces;
using ProGestor.Infraestruture.Data;

namespace ProGestor.Infraestruture.Repository;

public class CivilEngineeringDesignRepository: BaseRepository<CivilEngineeringDesigns>, ICivilEngineeringDesignRepository
{
    public CivilEngineeringDesignRepository(ProGestorDbContext context) : base(context)
    {
    }
}