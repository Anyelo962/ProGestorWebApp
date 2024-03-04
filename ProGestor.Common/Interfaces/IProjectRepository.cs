using ProGestor.Common.Dtos;
using ProGestor.Common.Entities;

namespace ProGestor.Common.Interfaces;

public interface IProjectRepository: IBaseRepository<Project>
{
    Task<List<ProjectDTO>> GetAllProject();

}