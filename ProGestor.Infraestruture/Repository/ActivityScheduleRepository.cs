using ProGestor.Common.Entities;
using ProGestor.Common.Interfaces;
using ProGestor.Infraestruture.Data;

namespace ProGestor.Infraestruture.Repository;

public class ActivityScheduleRepository: BaseRepository<ActivitySchedule>, IActivityScheduleRepository
{
    public ActivityScheduleRepository(ProGestorDbContext context) : base(context)
    {
    }
}