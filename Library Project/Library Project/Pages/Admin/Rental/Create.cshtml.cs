#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Library_Project.Data;

namespace Library_Project.Pages.Admin.Rental
{
    public class CreateModel : PageModel
    {
        private readonly Library_Project.Data.AppDbContext _context;

        public CreateModel(Library_Project.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Data.Rental Rental { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var members = _context.Members.ToList();
            var booktitles = _context.Books.ToList();

            List<string> fullNames = new List<string>();
            List<string> bookTitles = new List<string>();
            List<int> bookIds = new List<int>();

            foreach (var member in members)
            {
                fullNames.Add(member.FirstName + " " + member.LastName);
            }

            foreach (var bookt in booktitles)
            {
                bookTitles.Add(bookt.Title);
                bookIds.Add(bookt.Id);
            }

            if (!fullNames.Any(p => Rental.RentalMemberName.Contains(p)))
            {
                return RedirectToPage("./Index");
            }

            if (fullNames.Any(p => Rental.RentalMemberName.Contains(p)))
            {
                if (!bookTitles.Any(p => Rental.RentalBookTitle.Contains(p)))
                {
                    return RedirectToPage("./Index");
                }
            }

            _context.Rental.Add(Rental);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
