using Org.Project.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Org.Project.Application.Contracts.Persistence
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
        Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate);
    }
}
