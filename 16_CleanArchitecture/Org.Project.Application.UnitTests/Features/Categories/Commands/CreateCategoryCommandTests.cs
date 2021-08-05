using AutoMapper;
using Moq;
using Org.Project.Application.Contracts.Persistence;
using Org.Project.Application.Features.Categories.Commands.CreateCategory;
using Org.Project.Application.Profiles;
using Org.Project.Application.UnitTests.Mocks;
using Org.Project.Domain.Entities;
using Shouldly;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Org.Project.Application.UnitTests.Features.Categories.Commands
{
    public class CreateCategoryCommandTests
    {
        private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var configProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configProvider.CreateMapper();

        }

        [Fact]
        public async Task Handle_ValidCategory_AddedToCategoriesRepo()
        {
            // Arrange
            var handler = new CreateCategoryCommand.CreateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);

            // Act
            var result = await handler.Handle(new CreateCategoryCommand { Name = "Test" }, default);

            // Assert
            var allCategories = await _mockCategoryRepository.Object.ListAllAsync();
            allCategories.Count.ShouldBe(5);
            allCategories.ShouldContain(allCategories.First(x => x.Name == "Test"));
            allCategories.First(x => x.Name == "Test").ShouldBeOfType<Category>();
        }
    }
}
