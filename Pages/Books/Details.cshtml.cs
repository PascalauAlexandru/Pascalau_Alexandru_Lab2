using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pascalau_Alexandru_Lab2.Data;
using Pascalau_Alexandru_Lab2.Models;

namespace Pascalau_Alexandru_Lab2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Pascalau_Alexandru_Lab2.Data.Pascalau_Alexandru_Lab2Context _context;

        public DetailsModel(Pascalau_Alexandru_Lab2.Data.Pascalau_Alexandru_Lab2Context context)
        {
            _context = context;
        }

        public Models.Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Modificati aceasta interogare:
            Book = await _context.Book
                .Include(b => b.Publisher) 

               
                .Include(b => b.BookCategories)
                .ThenInclude(b => b.Category)

                .AsNoTracking() 
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
