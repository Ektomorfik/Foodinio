using Foodinio.Core.Enums;

namespace Foodinio.Core.Domain
{
    public class Dish : BaseEntity
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string Price { get; protected set; }
        public string PicturePath { get; protected set; }
        public MealType MealType { get; set; }
        protected Dish()
        {

        }
    }
}