﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.DAL.Entities;

namespace WebApplication1.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.DAL.Data.ApplicationDbContext _context;

        public IndexModel(WebApplication1.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Dish> Dish { get;set; }

        public async Task OnGetAsync()
        {
            Dish = await _context.Dishes
                .Include(d => d.Group).ToListAsync();
        }
    }
}
