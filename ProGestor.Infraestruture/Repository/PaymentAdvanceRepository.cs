using ProGestor.Common.Entities;
using ProGestor.Common.Interfaces;
using ProGestor.Infraestruture.Data;

namespace ProGestor.Infraestruture.Repository;

public class PaymentAdvanceRepository: BaseRepository<PaymentAdvance>, IPaymentAdvanceRepository
{
    public PaymentAdvanceRepository(ProGestorDbContext context) : base(context)
    {
    }
}