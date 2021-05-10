using WebApplication1.DAL.Entities;

namespace WebApplication1.DAL.Entities
{
    public class Dish
    {
        public int DishId { get; set; }
        public string DishName { get; set; }
        public string Description { get; set; }
        public int Calories { get; set; }
        public string Image { get; set; }

        public int DishGroupId { get; set; }
        public DishGroup Group { get; set; }
    }
}