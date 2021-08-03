using AutoMapper;
using MediatR;
using Org.Project.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Org.Project.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class GetCategoriesListWithEventsQuery :IRequest<List<CategoryEventListDto>>
    {
        public bool IncludeHistory { get; set; }

        public class GetCategoriesListWithEventsQueryHandler : IRequestHandler<GetCategoriesListWithEventsQuery, List<CategoryEventListDto>>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public GetCategoriesListWithEventsQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }
            public async Task<List<CategoryEventListDto>> Handle(GetCategoriesListWithEventsQuery request, CancellationToken cancellationToken)
            {
                var list = await _categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);

                return _mapper.Map<List<CategoryEventListDto>>(list);
            }
        }
    }
}
