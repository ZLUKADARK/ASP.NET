using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL.Entities;
using WebApplication1.Models;
using WebApplication1.Extensions;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        public List<Dish> _dishes;
        List<DishGroup> _dishGroups;
        int _pageSize;
        public ProductController()
        {
            _pageSize = 3;
            SetupData();

        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {

            var dishesFiltered = _dishes
            .Where(d => !group.HasValue || d.DishGroupId == group.Value);
            // Получить id текущей группы и поместить в TempData
            ViewData["Groups"] = _dishGroups;
            ViewData["CurrentGroup"] = group ?? 0;

            var model = ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }
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
                    Calories =180, DishGroupId=3, Image="s1.jpg" },
                    new Dish { DishId = 2, DishName="Томатный суп",
                    Description="Лук, чеснок, помидоры, итальянские травы, перец",
                    Calories =330, DishGroupId=3, Image="s2.jpg" },
                    new Dish { DishId = 3, DishName="Салат сыттов",
                    Description="Фасоль, корейская морковь, сыр, сухари, зелень.",
                    Calories =120, DishGroupId=2, Image="sl1.jpg" },
                    new Dish { DishId = 4, DishName="Салат с тунцом",
                    Description="Тунец, салат, помидор. Подается в пите из пшеничной муки",
                    Calories =240, DishGroupId=2, Image="sl2.jpg" },
                    new Dish { DishId = 5, DishName="Морс Gedonia клюква",
                    Description="500 мл, Вода очищенная, клюква, сахар, брусника.",
                    Calories =55, DishGroupId=5, Image="n1.jpg" },
                    new Dish { DishId = 5, DishName="Fanta",
                    Description="500 мл, Газированный напиток со вкусом апельсина.",
                    Calories =40, DishGroupId=5, Image="n2.jpeg" }
                };
        }
    }
}
