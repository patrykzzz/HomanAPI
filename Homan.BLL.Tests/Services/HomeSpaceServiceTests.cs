using System;
using AutoFixture;
using Homan.BLL.Services;
using Homan.DAL.Entities;
using Homan.DAL.Repositories.Abstract;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace Homan.BLL.Tests.Services
{
    [Collection("AutoMapper")]
    public class HomeSpaceServiceTests
    {
        private readonly HomeSpaceService _target;
        private readonly Mock<IHomeSpaceRepository> _homeSpaceRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private readonly IFixture _fixture;

        public HomeSpaceServiceTests()
        {
            _homeSpaceRepository = new Mock<IHomeSpaceRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            var userStore = new Mock<IUserStore<User>>();
            var userManager = new UserManager<User>(userStore.Object, null, null, null, null, null, null, null, null);
            _fixture = new Fixture();
            _target = new HomeSpaceService(_homeSpaceRepository.Object, _unitOfWork.Object, userManager);

            _fixture.Customize<HomeSpace>(cfg => cfg
                .Without(hs => hs.HomeSpaceItems)
                .Without(hs => hs.HomeSpaceUsers));
        }

        [Fact]
        public void GetHomeSpace_ForExistingHomeSpace_ShouldReturnHomeSpace()
        {
            // Arrange
            var entity = _fixture.Create<HomeSpace>();
            _homeSpaceRepository.Setup(x => x.GetById(entity.Id))
                .Returns(entity);

            // Act
            var result = _target.GetHomeSpace(entity.Id);

            // Assert
            Assert.Equal(entity.Id, result.Data.Id);
            Assert.Equal(entity.City, result.Data.City);
            Assert.Equal(entity.Name, result.Data.Name);
        }

        [Fact]
        public void GetHomeSpace_ForSomethingWrong_ShouldFail()
        {
            // Arrange
            _homeSpaceRepository.Setup(x => x.GetById(It.IsAny<Guid>()))
                .Throws<Exception>();

            // Act
            var result = _target.GetHomeSpace(Guid.NewGuid());

            // Assert
            Assert.False(result.Succeeded);
        }
    }
}