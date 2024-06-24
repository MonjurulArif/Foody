using FoodyWeb.Data;
using FoodyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodyWeb.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost(Category category)
        {
            if (ModelState.IsValid)
            {
                await _db.Category.AddAsync(category);

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
