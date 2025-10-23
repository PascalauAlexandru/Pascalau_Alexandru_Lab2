using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pascalau_Alexandru_Lab2.Data;
using Pascalau_Alexandru_Lab2.Models;

namespace Pascalau_Alexandru_Lab2.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Pascalau_Alexandru_Lab2.Data.Pascalau_Alexandru_Lab2Context _context;

        public CreateModel(Pascalau_Alexandru_Lab2.Data.Pascalau_Alexandru_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var authorList = _context.Authors.Select(x => new
            {
                x.Id,
                FullName = x.LastName + " " + x.FirstName
            });

            // property name is "Id" in the anonymous type, not "ID"
            ViewData["AuthorID"] = new SelectList(authorList, "Id", "FullName");
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID",
            "PublisherName");
            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            PopulateAssignedCategoryData(_context, book);
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }


        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            if (!ModelState.IsValid)
            {
                // repopulate selects and categories for redisplay
                var authorList = _context.Authors.Select(x => new
                {
                    x.Id,
                    FullName = x.LastName + " " + x.FirstName
                });
                ViewData["AuthorID"] = new SelectList(authorList, "Id", "FullName");
                ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");
                PopulateAssignedCategoryData(_context, Book ?? new Book());
                return Page();
            }

            var newBook = new Book();
            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }
            // attach categories selected to the bound Book instance
            Book.BookCategories = newBook.BookCategories;

            _context.Book.Add(Book);
            // <-- Save changes so the new book is persisted to the database
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
