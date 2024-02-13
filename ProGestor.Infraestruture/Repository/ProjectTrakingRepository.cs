using ProGestor.Common.Entities;
using ProGestor.Common.Interfaces;
using ProGestor.Infraestruture.Data;

namespace ProGestor.Infraestruture.Repository;

public class ProjectTrakingRepository: BaseRepository<ProjectTracking>, IProjectTrackingRepository
{
    public ProjectTrakingRepository(ProGestorDbContext context) : base(context)
    {
    }
}