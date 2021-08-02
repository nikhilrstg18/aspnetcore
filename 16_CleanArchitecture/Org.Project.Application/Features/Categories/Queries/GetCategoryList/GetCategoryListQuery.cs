using AutoMapper;
using MediatR;
using Org.Project.Application.Contracts.Persistence;
using Org.Project.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Org.Project.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQuery : IRequest<List<CategoryListDto>>
    {
        public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, List<CategoryListDto>>
        {
            private readonly IMapper _mapper;
            private readonly IAsyncRepository<Category> _categoryRepository;

            public GetCategoryListQueryHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
            {
                _mapper = mapper;
                _categoryRepository = categoryRepository;


            }
            public async Task<List<CategoryListDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
            {
                var allCategories = (await _categoryRepository.ListAllAsync()).OrderBy(x => x.Name);

                return _mapper.Map<List<CategoryListDto>>(allCategories);
            }
        }
    }
}
