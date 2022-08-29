using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Frases_Lowsedo.Model
{
    public class FrasesLowsedoDBContext : IdentityDbContext
    {

        public FrasesLowsedoDBContext(DbContextOptions<FrasesLowsedoDBContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Quote> Quotes { get; set; }

    }
}
