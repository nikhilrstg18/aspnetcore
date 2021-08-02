using Org.Project.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using Org.Project.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Org.Project.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithEvents(bool includeHistory);
    }
}
