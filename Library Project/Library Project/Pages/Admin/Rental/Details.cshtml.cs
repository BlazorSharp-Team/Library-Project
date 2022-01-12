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
    public class DetailsModel : PageModel
    {
        private readonly Library_Project.Data.AppDbContext _context;

        public DetailsModel(Library_Project.Data.AppDbContext context)
        {
            _context = context;
        }

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
    }
}
