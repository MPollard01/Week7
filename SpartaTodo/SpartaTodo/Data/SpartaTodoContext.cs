using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpartaTodo.Models;

namespace SpartaTodo.Data
{
    public class SpataTodoContext : IdentityDbContext
    {
        public SpataTodoContext()
        {

        }
        public SpataTodoContext(DbContextOptions<SpataTodoContext> options)
            : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
    }
}