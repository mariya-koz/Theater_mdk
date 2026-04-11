using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Theater_mdk.Data;
using Theater_mdk.Models;

namespace Theater_mdk.Pages.Tickets
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDBContext _context;
       // private readonly IHubContext<TicketHub> _hubContext;

        //public EditModel(ApplicationDBContext context, IHubContext<BookHub> hubContext)
        //{
        //    _context = context;
        //    _hubContext = hubContext;
        //}

        [BindProperty]
        public Ticket? Ticket { get; set; }

        public IActionResult OnGet(int id)
        {
            Ticket = _context.Ticket
                        .Where(c => c.Id == id)
                        .FirstOrDefault();

            if (Ticket == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Ticket.Update(Ticket);
            _context.SaveChanges();

            // Отправляем обновление всем клиентам
          //  _hubContext.Clients.All.SendAsync("BookUpdated", Ticket);

            return RedirectToPage("Index");
        }
    }
}
