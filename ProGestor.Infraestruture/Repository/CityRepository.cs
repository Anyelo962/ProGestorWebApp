using ProGestor.Common.Entities;
using ProGestor.Common.Interfaces;
using ProGestor.Infraestruture.Data;

namespace ProGestor.Infraestruture.Repository;

public class CityRepository: BaseRepository<City>, ICityRepository
{
    public CityRepository(ProGestorDbContext context) : base(context)
    {
        
    }
}