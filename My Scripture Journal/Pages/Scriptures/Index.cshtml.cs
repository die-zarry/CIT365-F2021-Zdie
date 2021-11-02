using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using My_Scripture_Journal.Data;
using My_Scripture_Journal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace My_Scripture_Journal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly My_Scripture_Journal.Data.My_Scripture_JournalContext _context;

        public IndexModel(My_Scripture_Journal.Data.My_Scripture_JournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ScriptureBook { get; set; }

       // [BindProperty(SupportsGet = true)]
        //public string SearchString { get; set; }
        //public SelectList Books { get; set; }
        //[BindProperty(SupportsGet = true)]
        //public SelectList Note { get; set; }
       // [BindProperty(SupportsGet = true)]
        //public string ScriptureBook { get; set; }
        //public string ScriptureNote { get; set; }
       
        public async Task OnGetAsync()
        {

            // Use LINQ to get list of genres.
            IQueryable<string> bookQuery = from m in _context.Scripture
                                           orderby m.Book
                                           select m.Book;

            var scriptures = from m in _context.Scripture
                         select m;
            
            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures  = scriptures.Where(s => s.Book.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(ScriptureBook))
            {
                scriptures = scriptures.Where(x => x.Book == ScriptureBook);
            }
            Books = new SelectList(await bookQuery.Distinct().ToListAsync());

            Scripture = await _context.Scripture.ToListAsync();
        }
    }
}
