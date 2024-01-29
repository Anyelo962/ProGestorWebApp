using ProGestor.Common.Entities;
using ProGestor.Common.Interfaces;
using ProGestor.Infraestruture.Data;

namespace ProGestor.Infraestruture.Repository;

public class ProjectRepository: BaseRepository<Project>, IProjectRepository
{
    public ProjectRepository(ProGestorDbContext context) : base(context)
    {
    }
}