using Org.Project.Domain.Entities;

namespace Org.Project.Application.Contracts.Persistence
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
    }
}
