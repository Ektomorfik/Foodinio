using System;

namespace Foodinio.Core.Domain
{
    public class Dish : BaseEntity
    {
        public Guid BlanketOrderId { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public decimal Price { get; protected set; }
        public string PicturePath { get; protected set; }
        public MealType MealType { get; protected set; }
        protected Dish()
        {

        }
    }
}