using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Theater_mdk.Data;
using Theater_mdk.Models;

namespace Theater_mdk.Pages.Tickets
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public DeleteModel(ApplicationDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ticket? Ticket { get; set; }

        public IActionResult OnGet(int id)
        {
            Ticket = _context.Ticket.FirstOrDefault(s => s.Id == id);  

            if (Ticket == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            var book = _context.Ticket.Find(Ticket.Id);

            if (book != null)
            {
                _context.Ticket.Remove(book);
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
