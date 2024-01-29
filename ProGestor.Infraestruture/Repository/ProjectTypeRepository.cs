using ProGestor.Common.Entities;
using ProGestor.Common.Interfaces;
using ProGestor.Infraestruture.Data;

namespace ProGestor.Infraestruture.Repository;

public class ProjectTypeRepository: BaseRepository<ProjectType>, IProjectTypeRepository
{
    public ProjectTypeRepository(ProGestorDbContext context) : base(context)
    {
    }
}