using Foody.DataAccess.Data;
using Foody.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodyWeb.Pages.Admin.FoodTypes
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IEnumerable<FoodType> FoodTypes { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            FoodTypes = _db.FoodType;
        }
    }
}
