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

        public DbSet<Ticket> Books { get; set; }
        public DbSet<Audience> Students { get; set; }
    }
}
