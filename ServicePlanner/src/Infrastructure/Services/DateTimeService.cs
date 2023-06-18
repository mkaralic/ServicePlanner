using ServicePlanner.Application.Common.Interfaces;

namespace ServicePlanner.Infrastructure.Services;
public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
