using System;
using Foodinio.Core.Domain;
using Foodinio.Core.Exceptions;
using Xunit;

namespace Foodinio.Tests.Domain
{
    public class UserTests
    {
        [Fact]
        public void set_first_name_throws_exception_when_firstName_is_empty()
        {
            Action action = () =>
            {
                var user = new User(Guid.NewGuid(), "test@email.com", "", "lastName", "secret", "salt", "user");
            };
            Assert.Throws<DomainException>(action);
        }
        [Fact]
        public void set_last_name_throws_exception_when_lastName_is_empty()
        {
            Action action = () =>
            {
                var user = new User(Guid.NewGuid(), "test@email.com", "firstName", "", "secret", "salt", "user");
            };
            Assert.Throws<DomainException>(action);
        }
    }
}