using Foody.DataAccess.Data;
using Foody.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;

namespace FoodyWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
 
        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            //Find work on Primary Key of the Table
            Category = _db.Category.Find(id);
            //Category = _db.Category.FirstOrDefault(u=>u.Id==id);
            //Category = _db.Category.SingleOrDefault(u=>u.Id==id);
            //Category = _db.Category.Where(u=>u.Id==id).FirstOrDefault();
        }
  
        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                //ModelState.AddModelError(string.Empty, "The DisplayOrder cannot exactly match the Name...!");
                ModelState.AddModelError("Category.Name", "The DisplayOrder cannot exactly match the Name...!");
            }

            else if (String.IsNullOrWhiteSpace(Category.Name))
            {
                //ModelState.AddModelError(string.Empty, "The DisplayOrder can not be Empty...!");
                ModelState.AddModelError("Category.Name", "The DisplayOrder can not be Empty...!");
            }

            else if (!Regex.IsMatch(Category.Name, @"^[a-zA-Z][a-zA-Z0-9_\-\. ]*$"))
            {
                //ModelState.AddModelError(string.Empty, "The DisplayOrder cannot be Special Characters or only Digits...!");
                ModelState.AddModelError("Category.Name", "The DisplayOrder cannot be Special Characters or only Digits...!");
            }

            if (ModelState.IsValid)
            {
                 _db.Category.Update(Category);

                await _db.SaveChangesAsync();

                TempData["success"] = "Category updated successfully...!";

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
