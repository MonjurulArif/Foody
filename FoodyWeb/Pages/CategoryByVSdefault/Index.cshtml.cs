using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FoodyWeb.Data;
using FoodyWeb.Model;

namespace FoodyWeb.Pages.CategoryByVSdefault
{
    public class IndexModel : PageModel
    {
        private readonly FoodyWeb.Data.ApplicationDbContext _context;

        public IndexModel(FoodyWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
