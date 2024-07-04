using Foody.DataAccess.Data;
using Foody.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;

namespace FoodyWeb.Pages.Admin.Categories
{
    [BindProperties]
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
  
        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                //ModelState.AddModelError(string.Empty, "The DisplayOrder cannot exactly match the Name...!");
                ModelState.AddModelError("Category.Name", "The DisplayOrder cannot exactly match the Name...!");
            }

            else if (String.IsNullOrWhiteSpace(Category.Name))
            {
                //ModelState.AddModelError(string.Empty, "The Category Name can not be Empty...!");
                ModelState.AddModelError("Category.Name", "The Category Name can not be Empty...!");
            }

            else if (!Regex.IsMatch(Category.Name, @"^[a-zA-Z][a-zA-Z0-9_\-\. ]*$"))
            {
                //ModelState.AddModelError(string.Empty, "The Category Name cannot Special Characters or only Digits...!");
                ModelState.AddModelError("Category.Name", "The Category Name cannot be Special Characters or only Digits...!");
            }

            if (ModelState.IsValid)
            {
                await _db.Category.AddAsync(Category);

                await _db.SaveChangesAsync();

                TempData["success"] = "Category created successfully...!";

                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
