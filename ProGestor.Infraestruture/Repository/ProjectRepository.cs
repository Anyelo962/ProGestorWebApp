using Microsoft.EntityFrameworkCore;
using ProGestor.Common.Dtos;
using ProGestor.Common.Entities;
using ProGestor.Common.Interfaces;
using ProGestor.Infraestruture.Data;

namespace ProGestor.Infraestruture.Repository;

public class ProjectRepository: BaseRepository<Project>, IProjectRepository
{

    private readonly ProGestorDbContext _context;
    public ProjectRepository(ProGestorDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<ProjectDTO>> GetAllProject()
    {
        var result = await  _context.Projects.Include(x => x.ProjectType)
            .Include(x => x.StatusProject)
            .Include(x => x.User).Select(x => new ProjectDTO()
            {
                Id = x.Id,
                ProjectTypeName = x.ProjectType.name,
                FirstName = x.User.firstName,
                LastName = x.User.lastName,
                DateProjectStart = x.DateProjectStart,
               DateProjectEnd = x.DateProjectEnd,
                StatusProjectName = x.StatusProject.name,
               Quoter = x.quoter
            }).ToListAsync();

        return result;

    }
}