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
    public class IndexModel : PageModel
    {
        private readonly Library_Project.Data.AppDbContext _context;

        public IndexModel(Library_Project.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Data.Rental> Rental { get;set; }

        public async Task OnGetAsync()
        {
            Rental = await _context.Rental.ToListAsync();
        }
    }
}
