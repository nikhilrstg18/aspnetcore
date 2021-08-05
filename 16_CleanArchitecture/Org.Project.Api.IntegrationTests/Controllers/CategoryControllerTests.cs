using Newtonsoft.Json;
using Org.Project.Api.IntegrationTests.Base;
using Org.Project.Application.Features.Categories.Queries.GetCategoryList;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Org.Project.Api.IntegrationTests.Controllers
{
    public class CategoryControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public CategoryControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsSuccessResult()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/categories");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<CategoryListDto>>(responseString);

            Assert.IsType<List<CategoryListDto>>(result);
            Assert.NotEmpty(result);
        }
    }
}
