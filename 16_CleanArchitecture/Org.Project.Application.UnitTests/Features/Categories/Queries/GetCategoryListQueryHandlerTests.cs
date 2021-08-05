using AutoMapper;
using Moq;
using Org.Project.Application.Contracts.Persistence;
using Org.Project.Application.Features.Categories.Queries.GetCategoryList;
using Org.Project.Application.Profiles;
using Org.Project.Application.UnitTests.Mocks;
using Org.Project.Domain.Entities;
using Shouldly;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Org.Project.Application.UnitTests.Features.Categories.Queries
{
    public class GetCategoryListQueryHandlerTests
    {
        private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryListQueryHandlerTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var configProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configProvider.CreateMapper();

        }

        [Fact]
        public async Task GetCategoriesListTest()
        {
            // Arrange
            var handler = new GetCategoryListQuery.GetCategoryListQueryHandler(_mapper, _mockCategoryRepository.Object);

            // Act
            var result = await handler.Handle(new GetCategoryListQuery(), default);

            // Assert
            result.ShouldBeOfType<List<CategoryListDto>>();
            result.Count.ShouldBe(4);
        }
    }
}
