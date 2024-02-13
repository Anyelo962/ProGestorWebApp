using ProGestor.Common.Entities;
using ProGestor.Common.Interfaces;
using ProGestor.Infraestruture.Data;

namespace ProGestor.Infraestruture.Repository;

public class InvoiceRepository: BaseRepository<Invoice>, IInvoiceRepository
{
    public InvoiceRepository(ProGestorDbContext context) : base(context)
    {
    }
}