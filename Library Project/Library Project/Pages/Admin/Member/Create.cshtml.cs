#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Library_Project.Data;

namespace Library_Project.Pages.Admin.Member
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
        public Data.Members Members { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Members.Add(Members);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
