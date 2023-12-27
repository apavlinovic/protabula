
using Microsoft.EntityFrameworkCore;

public class ScrapperDbContext : DbContext
{
    public DbSet<PrimaryRating> PrimaryRatings { get; set; }
    public DbSet<SecondaryRating> SecondaryRatings { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configure your database connection here
        // Example: optionsBuilder.UseSqlServer("your_connection_string");
        optionsBuilder.UseSqlite("Data Source=scraper.db");
    }
}
