using Foody.DataAccess.Data;
using Foody.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;

namespace FoodyWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public FoodType FoodType { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            //Find work on Primary Key of the Table
            FoodType = _db.FoodType.Find(id);

            //  --> FirstOrDefault: Retrieves the first entity that matches the condition
            //  FoodType = _db.FoodType.FirstOrDefault(u=>u.Id==id);

            //  --> SingleOrDefault: Retrieves the single entity that matches the condition
            //  FoodType = _db.FoodType.SingleOrDefault(u=>u.Id==id);

            //  --> Where + FirstOrDefault: This is a more explicit way to filter the entities using a Where clause and then retrieve the first matching entity using FirstOrDefault.
            //  FoodType = _db.FoodType.Where(u=>u.Id==id).FirstOrDefault();
        }

        public async Task<IActionResult> OnPost()
        {
            if (String.IsNullOrWhiteSpace(FoodType.Name))
            {
                //ModelState.AddModelError(string.Empty, "The Name can not be Empty...!");
                ModelState.AddModelError("FoodType.Name", "The Name can not be Empty ");
            }

            if (!Regex.IsMatch(FoodType.Name, @"^[a-zA-Z][a-zA-Z0-9_\-\. ]*$"))
            {
                //ModelState.AddModelError(string.Empty, "The Name can not be only Special Characters or only Digits...!");
                ModelState.AddModelError("FoodType.Name", "The Name can not be only Special Characters or only Digits...!");
            }

            if (ModelState.IsValid)
            {
                _db.FoodType.Update(FoodType);

                await _db.SaveChangesAsync();

                TempData["success"] = "FoodType updated successfully...!";

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
