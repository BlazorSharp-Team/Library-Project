﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Library_Project.Data;

namespace Library_Project.Pages.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly Library_Project.Data.AppDbContext _context;

        public DetailsModel(Library_Project.Data.AppDbContext context)
        {
            _context = context;
        }

        public Data.Books Books { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Books = await _context.Books.FirstOrDefaultAsync(m => m.Id == id);

            if (Books == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
