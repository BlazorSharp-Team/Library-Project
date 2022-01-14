#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Library_Project.Data;

namespace Library_Project.Pages.Admin.Rental
{
    public class DeleteModel : PageModel
    {
        private readonly Library_Project.Data.AppDbContext _context;

        public DeleteModel(Library_Project.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Data.Rental Rental { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rental = await _context.Rental.FirstOrDefaultAsync(m => m.RentalID == id);

            if (Rental == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rental = await _context.Rental.FindAsync(id);

            if (Rental != null)
            {
                _context.Rental.Remove(Rental);
                await _context.SaveChangesAsync();
            }
            var book = _context.Books.Where(p => p.isbnNumber == Rental.RentalBookIsbn).FirstOrDefault();
            if (book != null)
            {
                book.Quantity++;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
