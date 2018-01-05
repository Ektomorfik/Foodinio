using System;
using System.Threading.Tasks;
using AutoMapper;
using Foodinio.Core.Domain;
using Foodinio.Core.Repositories;
using Foodinio.Infrastructure.Exceptions;
using Foodinio.Infrastructure.Services;
using Foodinio.Infrastructure.Services.Encryption;
using Moq;
using Xunit;

namespace Foodinio.Tests.Services
{
    public class RegisterServiceTests
    {
        [Fact]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var encrypterMock = new Mock<IEncrypter>();
            encrypterMock.Setup(x => x.GetSalt(It.IsAny<string>())).Returns("hash");
            encrypterMock.Setup(x => x.GetHash(It.IsAny<string>(), It.IsAny<string>())).Returns("salt");
            var mapperMock = new Mock<IMapper>();

            var registerService = new RegisterService(userRepositoryMock.Object, encrypterMock.Object);
            await registerService.RegisterAsync(Guid.NewGuid(), "user1@email.com", "test", "test", "test", "test");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }

    }
}