using Microsoft.EntityFrameworkCore;

namespace Frases_Lowsedo.Model
{
    public class FrasesLowsedoDBContext : DbContext
    {

        public FrasesLowsedoDBContext(DbContextOptions<FrasesLowsedoDBContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Quote> Quotes { get; set; }

    }
}
