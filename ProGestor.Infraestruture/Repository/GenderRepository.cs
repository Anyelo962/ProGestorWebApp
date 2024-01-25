using ProGestor.Common.Entities;
using ProGestor.Common.Interfaces;
using ProGestor.Infraestruture.Data;

namespace ProGestor.Infraestruture.Repository;

public class GenderRepository: BaseRepository<Gender>, IGenderRepository
{
    public GenderRepository(ProGestorDbContext context) : base(context)
    {
    }
}