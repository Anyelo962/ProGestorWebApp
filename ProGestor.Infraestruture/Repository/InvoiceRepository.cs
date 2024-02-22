using ProGestor.Common.Entities;
using ProGestor.Common.Interfaces;
using ProGestor.Infraestruture.Data;

namespace ProGestor.Infraestruture.Repository;

public class InvoiceRepository: BaseRepository<Invoice>, IInvoiceRepository
{
    private readonly ProGestorDbContext _context;
    public InvoiceRepository(ProGestorDbContext context) : base(context)
    {
        this._context = context;
    }
}