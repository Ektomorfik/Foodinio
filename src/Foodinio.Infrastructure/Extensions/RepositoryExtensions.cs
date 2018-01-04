using System;
using System.Threading.Tasks;
using Foodinio.Core.Domain;
using Foodinio.Core.Repositories;
using Foodinio.Infrastructure.Exceptions;

namespace Foodinio.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<User> GetOrFailAsync(this IUserRepository repository, Guid userId)
        {
            var user = await repository.GetAsync(userId);
            if (user == null)
            {
                throw new ServiceException(ErrorCodes.UserNotFound, $"User with id: '{userId}' was not found.");
            }
            return user;
        }
        public static async Task<User> GetOrFailAsync(this IUserRepository repository, string email)
        {
            var user = await repository.GetAsync(email);
            if (user == null)
            {
                throw new ServiceException(ErrorCodes.UserNotFound, $"User with email: '{email}' was not found.");
            }
            return user;
        }
    }
}