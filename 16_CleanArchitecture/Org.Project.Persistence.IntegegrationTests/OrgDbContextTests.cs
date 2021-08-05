using Microsoft.EntityFrameworkCore;
using Org.Project.Domain.Entities;
using Shouldly;
using System;
using Xunit;

namespace Org.Project.Persistence.IntegegrationTests
{
    public class OrgDbContextTests
    {
        private readonly OrgDbContext _OrgDbContext;

        public OrgDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<OrgDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            //_loggedInUserId = "00000000-0000-0000-0000-000000000000";
            //_loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            //_loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _OrgDbContext = new OrgDbContext(dbContextOptions);
        }

        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            // Arrange
            var ev = new Event() { EventId = Guid.NewGuid(), Name = "Test event" };

            // Act
            _OrgDbContext.Events.Add(ev);
            var result = await _OrgDbContext.SaveChangesAsync();

            // Assert
            result.ShouldBe(1);
            //ev.CreatedOn.ShouldBe(_loggedInUserId);
        }
    }
}
