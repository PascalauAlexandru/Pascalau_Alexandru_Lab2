using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pascalau_Alexandru_Lab2.Data;
using Pascalau_Alexandru_Lab2.Models;

namespace Pascalau_Alexandru_Lab2.Pages.Authors
{
    public class CreateModel : PageModel
    {
        private readonly Pascalau_Alexandru_Lab2.Data.Pascalau_Alexandru_Lab2Context _context;

        public CreateModel(Pascalau_Alexandru_Lab2.Data.Pascalau_Alexandru_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Author Authors { get; set; } = default!;

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Authors.Add(Authors);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
