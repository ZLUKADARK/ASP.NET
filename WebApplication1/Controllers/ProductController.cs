using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL.Entities;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        List<Dish> _dishes;
        List<DishGroup> _dishGroups;
        public ProductController()
        {
            SetupData();
        }
        public IActionResult Index()
        {
            return View(_dishes);
        }
        /// <summary>
        /// Инициализация списков
        /// </summary>
        private void SetupData()
        {
            _dishGroups = new List<DishGroup>
                {
                    new DishGroup {DishGroupId=1, GroupName="Стартеры"},
                    new DishGroup {DishGroupId=2, GroupName="Салаты"},
                    new DishGroup {DishGroupId=3, GroupName="Супы"},
                    new DishGroup {DishGroupId=4, GroupName="Основные блюда"},
                    new DishGroup {DishGroupId=5, GroupName="Напитки"},
                    new DishGroup {DishGroupId=6, GroupName="Десерты"}
                };
            _dishes = new List<Dish>
                {
                    new Dish {DishId = 1, DishName="Грибной суп",
                    Description="Лук, картофель, сливки, грибы шампиньоны.",
                    Calories =180, DishGroupId=3, Image="Soup1.png" },
                    new Dish { DishId = 2, DishName="Томатный суп",
                    Description="Лук, чеснок, помидоры, итальянские травы, перец",
                    Calories =330, DishGroupId=3, Image="Soup2.jpg" },
                    new Dish { DishId = 3, DishName="Салат сыттов",
                    Description="Фасоль, корейская морковь, сыр, сухари, зелень.",
                    Calories =120, DishGroupId=4, Image="Salad.png" },
                    new Dish { DishId = 4, DishName="Салат с тунцом",
                    Description="Тунец, салат, помидор. Подается в пите из пшеничной муки",
                    Calories =240, DishGroupId=4, Image="Salad2.jpg" },
                    new Dish { DishId = 5, DishName="Морс Gedonia клюква",
                    Description="500 мл, Вода очищенная, клюква, сахар, брусника.",
                    Calories =55, DishGroupId=5, Image="Mors.png" },
                    new Dish { DishId = 5, DishName="Fanta",
                    Description="500 мл, Газированный напиток со вкусом апельсина.",
                    Calories =40, DishGroupId=5, Image="Fanta.png" }
                };
        }
    }
}
