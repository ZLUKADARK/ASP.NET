using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL.Data;
using WebApplication1.DAL.Entities;

namespace WebApplication1.Services
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                await roleManager.CreateAsync(roleAdmin);
            }
            if (!context.Users.Any())
            {
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }
            //проверка наличия групп объектов
            if (!context.DishGroups.Any())
            {
                context.DishGroups.AddRange(
                new List<DishGroup>
                {
                    new DishGroup {GroupName="Стартеры"},
                    new DishGroup {GroupName="Салаты"},
                    new DishGroup {GroupName="Супы"},
                    new DishGroup {GroupName="Основные блюда"},
                    new DishGroup {GroupName="Напитки"},
                    new DishGroup {GroupName="Десерты"}
                });
                await context.SaveChangesAsync();

            }
            // проверка наличия объектов
            if (!context.Dishes.Any())
            {
                context.Dishes.AddRange(
                new List<Dish>
                {
                    new Dish {DishName="Грибной суп",
                    Description="Лук, картофель, сливки, грибы шампиньоны.",
                    Calories =180, DishGroupId=3, Image="s1.jpg" },
                    new Dish {DishName="Томатный суп",
                    Description="Лук, чеснок, помидоры, итальянские травы, перец",
                    Calories =330, DishGroupId=3, Image="s2.jpg" },
                    new Dish {DishName="Салат сыттов",
                    Description="Фасоль, корейская морковь, сыр, сухари, зелень.",
                    Calories =120, DishGroupId=4, Image="sl1.jpg" },
                    new Dish {DishName="Салат с тунцом",
                    Description="Тунец, салат, помидор. Подается в пите из пшеничной муки",
                    Calories =240, DishGroupId=4, Image="sl2.jpg" },
                    new Dish {DishName="Морс Gedonia клюква",
                    Description="500 мл, Вода очищенная, клюква, сахар, брусника.",
                    Calories =55, DishGroupId=5, Image="n1.jpg" },
                    new Dish {DishName="Fanta",
                    Description="500 мл, Газированный напиток со вкусом апельсина.",
                    Calories =40, DishGroupId=5, Image="n2.jpeg" }
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
