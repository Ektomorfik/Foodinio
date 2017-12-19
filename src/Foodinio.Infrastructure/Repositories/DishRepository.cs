using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foodinio.Core.Domain;
using Foodinio.Core.Repositories;

namespace Foodinio.Infrastructure.Repositories
{
    public class DishRepository : IDishRepository
    {
        public Task<Dish> GetAsync(Guid dishId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Dish>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task AddAsync(Dish dish)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(Dish dish)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(Dish dish)
        {
            throw new NotImplementedException();
        }
    }
}