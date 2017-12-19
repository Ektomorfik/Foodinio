using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Foodinio.Core.Domain;

namespace Foodinio.Core.Repositories
{
    public interface IDishRepository : IRepository
    {
        Task<Dish> GetAsync(Guid dishId);
        Task<IEnumerable<Dish>> GetAllAsync();
        Task AddAsync(Dish dish);
        Task UpdateAsync(Dish dish);
        Task DeleteAsync(Dish dish);
    }
}