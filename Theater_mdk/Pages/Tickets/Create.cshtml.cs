using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Theater_mdk.Data;
using Theater_mdk.Models;

namespace Theater_mdk.Pages.Tickets
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public CreateModel(ApplicationDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ticket Ticket { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Ticket.Add(Ticket);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
