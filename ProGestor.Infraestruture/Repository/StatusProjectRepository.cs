using ProGestor.Common.Entities;
using ProGestor.Common.Interfaces;
using ProGestor.Infraestruture.Data;

namespace ProGestor.Infraestruture.Repository;

public class StatusProjectRepository: BaseRepository<StatusProject>, IStatusProjectRepository
{
    public StatusProjectRepository(ProGestorDbContext context) : base(context)
    {
    }
}