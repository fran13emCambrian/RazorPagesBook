using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesBook.Data;
using RazorPagesBook.Models;
using BindPropertyAttribute = Microsoft.AspNetCore.Mvc.BindPropertyAttribute;

namespace RazorPagesBook.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesBook.Data.RazorPagesBookContext _context;

        public IndexModel(RazorPagesBook.Data.RazorPagesBookContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Tittles { get; set; }
        public SelectList Authors { get; set; }
        [BindProperty(SupportsGet = true)]
        public string BookTittle { get; set; }
        public string BookAuthor { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> authorQuery = from b in _context.Book
                                             orderby b.Author
                                             select b.Author;

            var books = from b in _context.Book
                         select b;
            if (!string.IsNullOrEmpty(SearchString))
            {
                books = books.Where(s => s.Title.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(BookAuthor))
            {
                books = books.Where(x => x.Author == BookAuthor);
            }
            Authors = new SelectList(await authorQuery.Distinct().ToListAsync());

            Book = await books.ToListAsync();
        }
    }
}
