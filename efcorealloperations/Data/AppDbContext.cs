using efcorealloperations.Models;
using Microsoft.EntityFrameworkCore;

namespace efcorealloperations.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<BookPrice> BookPrices { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Currency> Currencies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Currency>().HasData(
            new Currency{Id = 1, CurrencyName = "INR"},
            new Currency{Id = 2, CurrencyName = "PON"},
            new Currency{Id = 3, CurrencyName = "USD"},
            new Currency{Id = 4, CurrencyName = "EUR"},
            new Currency{Id = 5, CurrencyName = "THB"},
            new Currency{Id = 6, CurrencyName = "WON"},
            new Currency{Id = 7, CurrencyName = "YEN"}
        );

        modelBuilder.Entity<Language>().HasData(
            new Language{Id = 1, LanguageDescription = "English"},
            new Language{Id = 2, LanguageDescription = "Dutch"},
            new Language{Id = 3, LanguageDescription = "Europian"},
            new Language{Id = 4, LanguageDescription = "Thai"},
            new Language{Id = 5, LanguageDescription = "Korean"},
            new Language{Id = 6, LanguageDescription = "Hindi"},
            new Language{Id = 7, LanguageDescription = "Japanese"}
        );
    }
}