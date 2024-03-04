using ProGestor.Common.Entities;
using ProGestor.Common.Interfaces;
using ProGestor.Infraestruture.Data;

namespace ProGestor.Infraestruture.Repository;

public class ProjectQuoteRepository: BaseRepository<Projectquote>, IProjectQuoteRepository
{
    public ProjectQuoteRepository(ProGestorDbContext context) : base(context)
    {
    }
}