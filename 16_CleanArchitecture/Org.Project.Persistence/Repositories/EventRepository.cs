using Org.Project.Application.Contracts.Persistence;
using Org.Project.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Org.Project.Persistence.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(OrgDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
        {
            var matches = _dbContext.Events
                .Any(e => e.Name.Equals(name) && e.Date.Date.Equals(eventDate));

            return Task.FromResult(matches);
        }
    }
}
