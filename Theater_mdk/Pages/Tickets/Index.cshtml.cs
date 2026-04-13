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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public IndexModel(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<Ticket> Ticket { get; set; }

        public void OnGet()
        {
            Ticket = _context.Ticket.ToList();
        }
    }
}
