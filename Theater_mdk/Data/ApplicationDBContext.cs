using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Theater_mdk.Models;

namespace Theater_mdk.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
        {
            //Database.Migrate();
        }

        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Audience> Audiences { get; set; }

    }
}
