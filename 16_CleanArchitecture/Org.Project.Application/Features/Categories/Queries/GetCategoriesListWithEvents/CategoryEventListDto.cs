using System;
using System.Collections.Generic;
using System.Text;

namespace Org.Project.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class CategoryEventListDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryEventDto> Events { get; set; }
    }
}
