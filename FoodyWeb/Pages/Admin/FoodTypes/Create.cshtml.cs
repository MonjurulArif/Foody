using Foody.DataAccess.Data;
using Foody.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;

namespace FoodyWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public FoodType FoodType { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (String.IsNullOrWhiteSpace(FoodType.Name))
            {
                //ModelState.AddModelError(string.Empty, "The FoodType Name can not be Empty...!");
                ModelState.AddModelError("FoodType.Name", "The FoodType Name can not be Empty ");
            }

            else if (!Regex.IsMatch(FoodType.Name, @"^[a-zA-Z][a-zA-Z0-9_\-\. ]*$"))
            {
                //ModelState.AddModelError(string.Empty, "The FoodType Name can not be Special Characters or only Digits...!");
                ModelState.AddModelError("FoodType.Name", "The FoodType Name can not be Special Characters or only Digits...!");
            }

            if (ModelState.IsValid)
            {
                await _db.FoodType.AddAsync(FoodType);

                await _db.SaveChangesAsync();

                TempData["success"] = "Food Type added successfully...!";

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
