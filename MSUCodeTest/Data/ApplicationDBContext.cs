

using Microsoft.EntityFrameworkCore;
using MSUCodeTest.Models.Entities;

namespace MSUCodeTest.Data

{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
                
        }

        public DbSet<Message> messages { get; set; }

    }
}
