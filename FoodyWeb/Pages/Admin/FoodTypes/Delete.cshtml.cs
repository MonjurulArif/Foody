using Foody.DataAccess.Data;
using Foody.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace FoodyWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public FoodType FoodType { get; set; }

        public DeleteModel(ApplicationDbContext db)
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
            var foodTypeFromDb = _db.FoodType.Find(FoodType.Id);

            if (foodTypeFromDb != null)
            {
                _db.FoodType.Remove(foodTypeFromDb);

                await _db.SaveChangesAsync();

                TempData["success"] = "Food Type deleted successfully";

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
